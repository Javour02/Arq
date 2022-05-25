using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    Button inicio;
    Button tutorial;
    public static int sceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        inicio = root.Q<Button>("inicio");
        tutorial = root.Q<Button>("tutorial");
        inicio.clicked += irNiveles;
        tutorial.clicked += irTutorial;

    }

    void irNiveles()
    {
        SceneManager.LoadScene("ChooseAspect");
    }

    void irTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
