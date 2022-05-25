using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class pauseMenu : MonoBehaviour
{
    Button menu;
    Button tutorial;
    Button continuar;
    static VisualElement root;
    bool isEnabled = false;
    // Start is called before the first frame update
    void Start()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        continuar = root.Q<Button>("continuar");
        tutorial = root.Q<Button>("controles");
        Debug.Log(continuar);
        menu = root.Q<Button>("inicio");
        continuar.clicked += quitarMenu;
        tutorial.clicked += irTutorial;
        menu.clicked += irMenu;
        root.visible = false;
    }

    public static void Prender()
    {
        root.visible = true;
    }
    void irTutorial()
    {
        root.visible = false;
        Controles.Prender();
    }

    void quitarMenu()
    {
        Debug.Log("esta entrando a la funcion");
        Time.timeScale = 1;
        isEnabled = false;
        root.visible = false;
    }

    void irMenu()
    {
        root.visible = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    // Update is called once per frame
    void Update()
    {
        continuar.clicked += quitarMenu;
        menu.clicked += irMenu;
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!isEnabled)
            {
                //VisualElement root = GetComponent<UIDocument>().rootVisualElement;
                Time.timeScale = 0;              
                isEnabled = true;
                root.visible = true;
                
            }
            else
            {
                Time.timeScale = 1;
                isEnabled = false;
                root.visible = false;
            }
            
        }
    }
}
