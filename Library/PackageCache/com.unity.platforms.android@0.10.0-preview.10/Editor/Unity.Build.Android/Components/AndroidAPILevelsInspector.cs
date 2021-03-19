using System.Collections.Generic;
using System.Linq;
using Unity.Properties.UI;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Unity.Build.Android
{
    sealed class AndroidAPILevelsInspector : Inspector<AndroidAPILevels>
    {
        PopupField<int> m_TargetApiPopup;

        internal static readonly SortedDictionary<int, string> s_AndroidCodeNames = new SortedDictionary<int, string>
        {
            { 0, "Automatic (highest installed)" },
            { 19, "Android 4.4 'KitKat' (API level 19)" },
            { 20, "Android 4.4W 'KitKat' (API level 20)" },
            { 21, "Android 5.0 'Lollipop' (API level 21)" },
            { 22, "Android 5.1 'Lollipop' (API level 22)" },
            { 23, "Android 6.0 'Marshmallow' (API level 23)" },
            { 24, "Android 7.0 'Nougat' (API level 24)" },
            { 25, "Android 7.1 'Nougat' (API level 25)" },
            { 26, "Android 8.0 'Oreo' (API level 26)" },
            { 27, "Android 8.1 'Oreo' (API level 27)" },
            { 28, "Android 9.0 'Pie' (API level 28)" },
            { 29, "Android 10.0 (API level 29)" },
        };

        private int ResolveIndex(List<int> choices, AndroidSdkVersions apiLevel)
        {
            for (int i = 0; i < choices.Count; i++)
            {
                if (choices[i] == (int)apiLevel)
                {
                    return i;
                }
            }

            return 0;
        }
        public override VisualElement Build()
        {
            var root = new VisualElement();

            var minAPIChoices = s_AndroidCodeNames.Keys.ToList().GetRange(1, s_AndroidCodeNames.Count - 1);
            var minApiPopup = new PopupField<int>(
                ObjectNames.NicifyVariableName(nameof(AndroidAPILevels.MinAPILevel)),
                minAPIChoices,
                ResolveIndex(minAPIChoices, Target.MinAPILevel),
                value => s_AndroidCodeNames[value],
                value => s_AndroidCodeNames[value])
            {
                bindingPath = nameof(AndroidAPILevels.MinAPILevel)
            };
            root.contentContainer.Add(minApiPopup);

            var targetAPIChoices = s_AndroidCodeNames.Keys.ToList();
            m_TargetApiPopup = new PopupField<int>(
                ObjectNames.NicifyVariableName(nameof(AndroidAPILevels.TargetAPILevel)),
                s_AndroidCodeNames.Keys.ToList(),
                ResolveIndex(targetAPIChoices, Target.TargetAPILevel),
                value => s_AndroidCodeNames[value],
                value => s_AndroidCodeNames[value])
            {
                bindingPath = nameof(AndroidAPILevels.TargetAPILevel)
            };
            root.contentContainer.Add(m_TargetApiPopup);

            return root;
        }
    }
}
