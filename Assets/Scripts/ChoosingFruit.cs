using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class ChoosingFruit : MonoBehaviour
{
    Button fresa;
    Button pera;
    Button limon;
    Button banano;
    public static int aspect = 0;

    // Start is called before the first frame update
    void Start()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        fresa = root.Q<Button>("Fresa");
        pera = root.Q<Button>("Pera");
        limon = root.Q<Button>("Limon");
        banano = root.Q<Button>("Banano");
        fresa.clicked += chooseF;
        pera.clicked += chooseP;
        limon.clicked += chooseL;
        banano.clicked += chooseB;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void chooseF()
    {
        aspect = 2;
        SceneManager.LoadScene("Levels");
    }

    void chooseP()
    {
        aspect = 0;
        SceneManager.LoadScene("Levels");
    }

    void chooseL()
    {
        aspect = 3;
        SceneManager.LoadScene("Levels");
    }
    void chooseB()
    {
        aspect = 1;
        SceneManager.LoadScene("Levels");

    }
}
