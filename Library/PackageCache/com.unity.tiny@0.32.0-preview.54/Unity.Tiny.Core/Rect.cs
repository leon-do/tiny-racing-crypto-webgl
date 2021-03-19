using Unity.Assertions;
using Unity.Mathematics;

namespace Unity.Tiny
{
    /// <summary>
    /// 2D rectangle
    /// </summary>
    public struct Rect
    {
        /// <summary>
        /// Default unit rectangle.
        /// </summary>
        public static Rect Default { get; } = new Rect()
        {
            x = 0f,
            y = 0f,
            width = 1f,
            height = 1f
        };

        public Rect(float x, float y, float width, float height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        public bool IsEmpty()
        {
            return !(width > 0.0f && height > 0.0f);
        }

        /// <summary>
        /// Returns true if <paramref name="pos"/> is inside this rectangle.
        /// </summary>
        /// <remarks>
        /// The left and bottom edges are inclusive, while the right and top edges
        /// are exclusive. Also, while this class doesn't forbid 0 or negative
        /// width / heights, Contains() will be always be false in that case.
        /// </remarks>
        public bool Contains(float2 pos)
        {
            return pos.x >= x && pos.y >= y && pos.x < x + width && pos.y < y + height;
        }

        public bool ContainsInclusive(float2 pos)
        {
            return pos.x >= x && pos.y >= y && pos.x <= x + width && pos.y <= y + height;
        }

        /// <summary>
        /// Returns true if <paramref name="other"/> is inside this rectangle.
        /// </summary>
        /// <remarks>
        /// The left and bottom edges are inclusive, while the right and top edges
        /// are exclusive. Also, while this class doesn't forbid 0 or negative
        /// width / heights, Contains() will be always be false in that case.
        /// </remarks>
        public bool ContainsInclusive(Rect other)
        {
            if ( other.IsEmpty() )
                return false;
            return ContainsInclusive(new float2(other.x, other.y)) &&
                   ContainsInclusive(new float2(other.x+other.width, other.y+other.height));
        }

        /// <summary>
        /// Returns true if <paramref name="other"/> is not overlapping with this rectangle.
        /// </summary>
        public bool Disjoint(Rect other)
        {
            if ( other.x >= x + width || other.y >= y + height )
                return true;
            if ( other.x + other.width <= x || other.y + other.height <= y )
                return true;
            return false;
        }

        /// <summary>
        /// Remove this rect from the other rect and return the up to four remaining pieces
        /// destRects must have enough space for four rectangles
        /// Returns the number of pieces other was broken up into.
        /// </summary>
        public unsafe int RemoveFrom(Rect other, Rect *destRects )
        {
            if ( Disjoint(other) ) {
                destRects[0] = other;
                return 1;
            }
            if ( ContainsInclusive(other) )
                return 0;
            // Always split like this: 
            // +--------------+
            // |      0       |
            // |----+----+----|
            // | 1  |this| 2  |
            // |----+----+----|
            // |      3       |
            // +--------------|
            // Then, only accept non-empty sub-rects
            // This will create three sub rects even when 2 would be enough
            int n = 0;
            destRects[n].x = other.x;
            destRects[n].y = other.y;
            destRects[n].width = other.width;
            destRects[n].height = math.min(y - other.y, other.height);
            if ( !destRects[n].IsEmpty() ) n++;
            
            destRects[n].x = other.x;
            destRects[n].y = y;
            destRects[n].width = math.min(x - other.x, other.width);
            destRects[n].height = math.min(height, other.height);
            if ( !destRects[n].IsEmpty() ) n++;
            
            destRects[n].x = x+width;
            destRects[n].y = y;
            destRects[n].width = math.min((other.x + other.width) - (x + width), other.width);
            destRects[n].height = math.min(height, other.height);
            if ( !destRects[n].IsEmpty() ) n++;

            destRects[n].x = x;
            destRects[n].y = y + height;
            destRects[n].width = other.width;
            destRects[n].height = (other.y + other.height) - (y+height);
            if ( !destRects[n].IsEmpty() ) n++;

            Assert.IsTrue(n==3);
            return n;
        }

        /// <summary>
        /// Returns a new rectangle translated and scaled by <paramref name="relative"/>.
        /// </summary>
        public Rect Region(in Rect relative)
        {
            return new Rect
            {
                x = x + relative.x * width,
                y = y + relative.y * height,
                width = width * relative.width,
                height = height * relative.height
            };
        }

        public void Clamp(Rect r)
        {
            float x2 = x + width;
            float y2 = y + height;
            float rx2 = r.x + r.width;
            float ry2 = r.y + r.height;
            if (x < r.x) x = r.x;
            if (x2 > rx2) x2 = rx2;
            if (y < r.y) y = r.y;
            if (y2 > ry2) y2 = ry2;
            width = x2 - x;
            if (width < 0.0f) width = 0.0f;
            height = y2 - y;
            if (height < 0.0f) height = 0.0f;
        }

        public float x;
        public float y;
        public float width;
        public float height;

        /// <summary>
        /// The width and height of the rectangle.
        /// </summary>
        public float2 Size
        {
            get => new float2(width, this.height);
            set
            {
                width = value.x;
                height = value.y;
            }
        }

        /// <summary>
        /// The position of the center of the rectangle.
        /// </summary>
        public float2 Center
        {
            get => new float2(x + width / 2f, y + height / 2f);
            set
            {
                x = value.x - width / 2f;
                y = value.y - height / 2f;
            }
        }
    }
}
