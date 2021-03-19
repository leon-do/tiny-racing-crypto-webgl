using System;
using System.Collections.Generic;
using Unity.Properties.UI;
using Unity.Build.Editor;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Unity.Build.Android
{
    sealed class AndroidIconsInspector : Inspector<AndroidIcons>
    {
        class AndroidIconsForDPISet : VisualElement
        {
            public AndroidIconsForDPISet(AndroidIconsInspector target, int index) : base()
            {
                var size = AndroidIcons.kSize[index];
                var legacySize = AndroidIcons.kLegacySize[index];
                Add(new IconSelector("adaptive foreground", size, size, target.Target.Icons[index].Foreground,
                    val => { target.Target.Icons[index].Foreground = val; target.NotifyChanged(); } ));
                Add(new IconSelector("adaptive background", size, size, target.Target.Icons[index].Background,
                    val => { target.Target.Icons[index].Background = val; target.NotifyChanged(); } ));
                Add(new IconSelector("legacy", legacySize, legacySize, target.Target.Icons[index].Legacy,
                    val => { target.Target.Icons[index].Legacy = val; target.NotifyChanged(); } ));
            }
        }

        AndroidIconsForDPISet[] m_IconsForDPISet = new AndroidIconsForDPISet[AndroidIcons.DPICount];
        EnumField m_ScreenDPI;

        public override VisualElement Build()
        {
            var root = new VisualElement();
            DoDefaultGui(root, nameof(AndroidIcons.ScreenDPI));
            m_ScreenDPI = root.Q<EnumField>(nameof(AndroidIcons.ScreenDPI));

            for (int i = 0; i < m_IconsForDPISet.Length; ++i)
            {
                m_IconsForDPISet[i] = new AndroidIconsForDPISet(this, i);
                root.Add(m_IconsForDPISet[i]);
            }
            return root;
        }

        public override void Update()
        {
            var dpi = Convert.ToInt32(m_ScreenDPI.value);
            for (int i = 0; i < m_IconsForDPISet.Length; ++i)
            {
                m_IconsForDPISet[i].style.display = i == dpi ? DisplayStyle.Flex : DisplayStyle.None;
            }
        }
    }
}
