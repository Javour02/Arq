using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Controles : MonoBehaviour
{
    Button volver;
    static VisualElement root;

    // Start is called before the first frame update
    void Start()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        volver = root.Q<Button>("volver");
        volver.clicked += Volver;
        root.visible = false;
    }

    void Volver()
    {
        root.visible = false;
        pauseMenu.Prender();
    }

    public static void Prender()
    {
        root.visible = true;
    }

    public static void Apagar()
    {
        root.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
