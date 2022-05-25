using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor.SceneManagement;
using UnityEngine.UIElements;

namespace Test.SystemTest
{


    public class Sistema
    {
        #region FIELDS
        private int scenes = 0;
        private GameObject jugador;
        private GameObject enemigo;

        #endregion

        #region TESTS

        //Todo lo que ocurre antes del test
        [SetUp]
        public void SetUp()
        {
            switch (scenes)
            {
                case 0:
                    EditorSceneManager.LoadScene("Menu");
                    break;
                case 1:
                    EditorSceneManager.LoadScene("Tutorial");
                    break;
                case 2:
                    EditorSceneManager.LoadScene("ChooseAspect");
                    break;
                case 3:
                    EditorSceneManager.LoadScene("Levels");
                    break;
                case 4:
                    EditorSceneManager.LoadScene("Level1");
                    break;
            }

        }

        //Test 1: "Ir a tutorial"
        [UnityTest]
        public IEnumerator PruebaA()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return new WaitUntil(() => EditorSceneManager.GetActiveScene().name.Equals("Tutorial"));
            scenes = 1;
            Assert.That(EditorSceneManager.GetActiveScene().name.Equals("Tutorial"));
        }

        //Test 2: "Ir a Menu (Volver)"
        [UnityTest]
        public IEnumerator PruebaB()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return new WaitUntil(() => EditorSceneManager.GetActiveScene().name.Equals("Menu"));
            scenes = 0;
            Assert.That(EditorSceneManager.GetActiveScene().name.Equals("Menu"));
        }

        //Test 3: "Ir a Escjoer Aspecto"
        [UnityTest]
        public IEnumerator PruebaC()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return new WaitUntil(() => EditorSceneManager.GetActiveScene().name.Equals("ChooseAspect"));
            scenes = 2;
            Assert.That(EditorSceneManager.GetActiveScene().name.Equals("ChooseAspect"));
        }

        //Test 4: "Ir a Niveles"
        [UnityTest]
        public IEnumerator PruebaD()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return new WaitUntil(() => EditorSceneManager.GetActiveScene().name.Equals("Levels"));
            scenes = 3;
            Assert.That(EditorSceneManager.GetActiveScene().name.Equals("Levels"));
        }

        //Test 5: "Ir al nivel 1"
        [UnityTest]
        public IEnumerator PruebaE()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return new WaitUntil(() => EditorSceneManager.GetActiveScene().name.Equals("Level1"));
            scenes = 4;
            Assert.That(EditorSceneManager.GetActiveScene().name.Equals("Level1"));
        }

        //Test 6: "El jugador existe en el juego"
        [UnityTest]
        public IEnumerator PruebaF()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
            jugador = GameObject.Find("Player");
            Assert.That(jugador != null);
        }

        //Test 7: "Movimiento a la derecha"
        [UnityTest]
        public IEnumerator PruebaG()
        {
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.RightArrow));
            jugador = GameObject.Find("Player");
            Assert.That(jugador.GetComponent<Rigidbody2D>().velocity.x != 0);

            //Assert.That(sphere.transform.position.y < cube.transform.position.y);
        }

        //Test 8: "Movimiento a la izquierda"
        [UnityTest]
        public IEnumerator PruebaH()
        {
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.LeftArrow));
            jugador = GameObject.Find("Player");
            yield return new WaitForSeconds(0.1f);
            Assert.That(jugador.GetComponent<Rigidbody2D>().velocity.x != 0);

            //Assert.That(sphere.transform.position.y < cube.transform.position.y);
        }

        //Test 9: "salto"
        [UnityTest]
        public IEnumerator PruebaI()
        {
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.UpArrow));
            jugador = GameObject.Find("Player");
            Assert.That(jugador.GetComponent<Rigidbody2D>().velocity.y != 0);
            //Assert.That(sphere.transform.position.y < cube.transform.position.y);
        }

        //Test 10: "enemigo"
        [UnityTest]
        public IEnumerator PruebaJ()
        {
            yield return null;
            enemigo = GameObject.Find("Chef");
            Assert.That(enemigo != null);
        }

        //Test 11: "Mecanicas enemigo"
        [UnityTest]
        public IEnumerator PruebaK()
        {
            enemigo = GameObject.Find("Chef");
            yield return new WaitForSeconds(0.2f);
            Assert.That(enemigo.GetComponent<Rigidbody2D>().velocity.x != 0);
        }

        [TearDown]
        public void TearDown()
        {
            switch (scenes)
            {
                case 0:
                    EditorSceneManager.UnloadSceneAsync("Menu");
                    break;
                case 1:
                    EditorSceneManager.UnloadSceneAsync("Tutorial");
                    break;
                case 2:
                    EditorSceneManager.UnloadSceneAsync("ChooseAspect");
                    break;
                case 3:
                    EditorSceneManager.UnloadSceneAsync("Levels");
                    break;
                case 4:
                    EditorSceneManager.UnloadSceneAsync("Level1");
                    break;
            }
        }
        #endregion
    }
}
