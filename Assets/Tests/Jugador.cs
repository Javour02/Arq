using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor.SceneManagement;


//Cómo encontramos en la jerarquía del test runner el orden de los test, empieza con la esfera
namespace Test.Sphere{


public class Jugador
{
    //Definición de las referencias para la prueba

    private GameObject sphere;
    private GameObject cube;
    


    //Todo lo que ocurre antes del test
    [SetUp]
    public void SetUp{

        EditorSceneManager.LoadScene("SampleScene");

    }

    //Test 1: "Ejemplo de vídeo: Esfera encima del cubo"
    [UnityTest]
    public IEnumerator PruebaUno()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;

        sphere = GameObject.Find("Sphere");
        cube = GameObject.Find("Cube");

        Assert.That(sphere.transform.position.y > cube.transform.position.y);
    }

    //Test 2: "Ejemplo de vídeo: Esfera abajo del cubo"
    [UnityTest]
    public IEnumerator PruebaDos()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return new WaitForSeconds(5);

        Assert.That(sphere.transform.position.y < cube.transform.position.y);
    }

    [Test]
    public void JugadorSimplePasses()
    {
        // Use the Assert class to test conditions
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    

    [TearDown]
    public void TearDown{
        EditorSceneManager.UnLoadSceneAsync("SampleScene");
    }
}
}
