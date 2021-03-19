using Unity.Properties.UI;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Unity.Build.Android
{
    sealed class AndroidAspectRatioInspector : Inspector<AndroidAspectRatio>
    {
        EnumField m_AspectRatioMode;
        FloatField m_CustomAspectRatio;

        public override VisualElement Build()
        {
            var root = new VisualElement();
            DoDefaultGui(root, nameof(AndroidAspectRatio.AspectRatioMode));
            DoDefaultGui(root, nameof(AndroidAspectRatio.CustomAspectRatio));

            m_AspectRatioMode = root.Q<EnumField>(nameof(AndroidAspectRatio.AspectRatioMode));
            m_CustomAspectRatio = root.Q<FloatField>(nameof(AndroidAspectRatio.CustomAspectRatio));

            return root;
        }

        public override void Update()
        {
            m_CustomAspectRatio.visible = (AspectRatioMode)m_AspectRatioMode.value == AspectRatioMode.Custom;
        }
    }
}
