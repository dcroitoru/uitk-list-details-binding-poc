using UnityEngine;
using UnityEditor;

public class MasterDetailWindow : EditorWindow {
    [MenuItem("MyTools/MasterDetailTest")]
    private static void Open() {
        var window = GetWindow<MasterDetailWindow>();
        window.titleContent = new GUIContent("MasterDetailWindow");
    }

    private void CreateGUI() {
        rootVisualElement.Add(new MasterDetail());

    }


}