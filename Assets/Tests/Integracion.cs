using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor.SceneManagement;
using UnityEngine.UIElements;

namespace Test.integrationTest
{
    public class Integracion
    {
        //Definición de las referencias para la prueba
        #region FIELDS
        private GameObject doc;
        private Button limon;
        private float collider;
        private GameObject jugador;
        private int scenes = 0;
        #endregion

        #region TESTS

        //Todo lo que ocurre antes del test
        [SetUp]
        public void SetUp()
        {
            if(scenes == 1)
            {
                EditorSceneManager.LoadScene("Level1");
            }
            else
            {
                EditorSceneManager.LoadScene("ChooseAspect");
            }
            
        }

        //Test 1: "Exista boton"
        [UnityTest]
        public IEnumerator PruebaA()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
            doc = GameObject.Find("UIDocument");
            VisualElement root = doc.GetComponent<UIDocument>().rootVisualElement;
            limon = root.Q<Button>("Limon");
            Assert.That(limon.enabledInHierarchy);
        }

        //Test 2: "Naveguación"
        [UnityTest]
        public IEnumerator PruebaB()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return new WaitUntil(() => EditorSceneManager.GetActiveScene().name.Equals("Level1"));
            scenes = 1;
            collider = 1.6f;
            Assert.That(EditorSceneManager.GetActiveScene().name.Equals("Level1"));
        }

        //Test 3: "Jugador con aspecto elegido"
        [UnityTest]
        public IEnumerator PruebaC()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return new WaitUntil(() => EditorSceneManager.GetActiveScene().name.Equals("Level1"));
            jugador = GameObject.Find("Player");
            Assert.That(jugador.GetComponent<BoxCollider2D>().size.x == collider);
        }

        [TearDown]
        public void TearDown()
        {
            if (EditorSceneManager.GetActiveScene().name.Equals("Level1"))
            {
                EditorSceneManager.UnloadSceneAsync("Level1");
            }
            else
            {
                EditorSceneManager.UnloadSceneAsync("ChooseAspect");
            }
        }
        #endregion
    }
}
