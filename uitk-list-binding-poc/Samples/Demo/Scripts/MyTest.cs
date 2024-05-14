using UnityEngine;
using UnityEngine.UIElements;

public class MyTest : MonoBehaviour {
    [SerializeField] UIDocument document;
    VisualElement root;

    private void Awake() {
        root = document.rootVisualElement;

        var master = new MasterDetail();



        root.Add(new Button() { name = "hello" });
        root.Add(new VisualElement() { name = "" });
        root.Add(master);
        Debug.Log($"document {root}");

    }
}
