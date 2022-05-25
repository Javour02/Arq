using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
public class levels : MonoBehaviour
{
    Button level1;
    Button level2;

    // Start is called before the first frame update
    void Start()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        level1 = root.Q<Button>("level1");
        level2 = root.Q<Button>("level2");
        level1.clicked += Level1;
        level2.clicked += Level2;


    }

    void Level1()
    {
        SceneManager.LoadScene("Level1");
    }

    void Level2()
    {
        SceneManager.LoadScene("Level2");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
