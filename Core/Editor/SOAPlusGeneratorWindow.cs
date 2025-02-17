using System.IO;
using UnityEditor;
using UnityEngine;

namespace SOAPlus.Core.Editor
{
    public class SoaPlusGeneratorWindow : EditorWindow
    {
        private string _typeName = "MyCustomType";
        private string _namespaceName = "com.brunomassa.soaplus.Generated";
        private bool _generateVariable = true;
        private bool _generateReference = true;
        private bool _generateEvent = true;

        [MenuItem("Window/Generate SOAPlus Type")]
        public static void ShowWindow() => GetWindow<SoaPlusGeneratorWindow>("SOAPlus Generator");

        private void OnGUI()
        {
            _typeName = EditorGUILayout.TextField("Type Name", _typeName);
            _namespaceName = EditorGUILayout.TextField("Namespace", _namespaceName);

            _generateVariable = EditorGUILayout.Toggle("Generate Variable", _generateVariable);
            _generateReference = EditorGUILayout.Toggle("Generate Reference", _generateReference);
            _generateEvent = EditorGUILayout.Toggle("Generate Event", _generateEvent);

            if (GUILayout.Button("Generate"))
            {
                GenerateFiles(_typeName, _namespaceName);
            }
        }

        private void GenerateFiles(string type, string namespaceName)
        {
            var outputPath = "Assets/";

            if (!Directory.Exists(outputPath))
            {
                Directory.CreateDirectory(outputPath);
            }

            if (_generateVariable)
            {
                var variableCode = $@"
using UnityEngine;
using com.brunomassa.soaplus.Core;

namespace {namespaceName} {{
    [CreateAssetMenu(fileName = ""{type}Variable"", menuName = ""SOAPlus/Generated/{type}Variable"")]
    public class {type}Variable : BaseVariable<{type}> {{

        public {type}Variable({type} initialValue) : base(initialValue)
        {{
        }}
    }}
}}";
                File.WriteAllText(outputPath + $"{type}Variable.cs", variableCode);
            }

            if (_generateReference)
            {
                var referenceCode = $@"
using UnityEngine;
using com.brunomassa.soaplus.Core;

namespace {namespaceName} {{
    [System.Serializable]
    public class {type}Reference : BaseReference<{type}, {type}Variable> {{ }}
}}";
                File.WriteAllText(outputPath + $"{type}Reference.cs", referenceCode);
            }

            if (_generateEvent)
            {
                var eventCode = $@"
using UnityEngine;
using com.brunomassa.soaplus.Core;

namespace {namespaceName} {{
    [CreateAssetMenu(fileName = ""{type}Event"", menuName = ""SOAPlus/Generated/{type}Event"")]
    public class {type}Event : BaseEvent<{type}> {{ }}
}}";
                File.WriteAllText(outputPath + $"{type}Event.cs", eventCode);
            }

            AssetDatabase.Refresh();
        }
    }
}
