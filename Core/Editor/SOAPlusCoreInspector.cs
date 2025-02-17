using UnityEditor;

namespace SOAPlus.Core.Editor
{
    [CustomEditor(typeof(BaseVariable<>), true)]
    public class SoaPlusCoreInspector : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            EditorGUILayout.HelpBox("This is a base variable. Inherit from this to create custom variables.", MessageType.Info);
        }
    }
}
