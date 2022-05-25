using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor.SceneManagement;

namespace Test.Navegability
{
    public class Navegabilidad
    {
        #region FIELDS
        private int scenes = 0;
        private GameObject jugador;
        private GameObject square;
        private GameObject enemigo;

        #endregion

        #region TESTS

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
                case 5:
                    EditorSceneManager.LoadScene("Level2");
                    break;
                case 6:
                    EditorSceneManager.LoadScene("Level3");
                    break;
                default:
                    break;
            }

        }

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

        //Test 1: "Colision con el suelo"
        [UnityTest]
        public IEnumerator PruebaF()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return new WaitForSeconds(2f);
            square = GameObject.Find("Square");
            jugador = GameObject.Find("Player");
            Assert.That(jugador.GetComponent<BoxCollider2D>().IsTouching(square.GetComponent<BoxCollider2D>()));
        }

        //Test 2: "Movimiento a la derecha"
        [UnityTest]
        public IEnumerator PruebaG()
        {
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.RightArrow));
            jugador = GameObject.Find("Player");
            Assert.That(jugador.GetComponent<Rigidbody2D>().velocity.x != 0);

            //Assert.That(sphere.transform.position.y < cube.transform.position.y);
        }

        //Test 3: "Movimiento a la izquierda"
        [UnityTest]
        public IEnumerator PruebaH()
        {
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.LeftArrow));
            jugador = GameObject.Find("Player");
            yield return new WaitForSeconds(0.1f);
            Assert.That(jugador.GetComponent<Rigidbody2D>().velocity.x != 0);

            //Assert.That(sphere.transform.position.y < cube.transform.position.y);
        }

        //Test 4: "salto"
        [UnityTest]
        public IEnumerator PruebaI()
        {
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.UpArrow));
            jugador = GameObject.Find("Player");
            Assert.That(jugador.GetComponent<Rigidbody2D>().velocity.y != 0);
            //Assert.That(sphere.transform.position.y < cube.transform.position.y);
        }

        [UnityTest]
        public IEnumerator PruebaK()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return new WaitUntil(() => EditorSceneManager.GetActiveScene().name.Equals("Level2"));
            scenes = 5;
            Assert.That(EditorSceneManager.GetActiveScene().name.Equals("Level2"));
        }

        //Test 1: "Colision con el suelo"
        [UnityTest]
        public IEnumerator PruebaL()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return new WaitForSeconds(2f);
            square = GameObject.Find("Square");
            jugador = GameObject.Find("Player");
            Assert.That(jugador.GetComponent<BoxCollider2D>().IsTouching(square.GetComponent<BoxCollider2D>()));
        }

        //Test 2: "Movimiento a la derecha"
        [UnityTest]
        public IEnumerator PruebaM()
        {
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.RightArrow));
            jugador = GameObject.Find("Player");
            Assert.That(jugador.GetComponent<Rigidbody2D>().velocity.x != 0);

            //Assert.That(sphere.transform.position.y < cube.transform.position.y);
        }

        //Test 3: "Movimiento a la izquierda"
        [UnityTest]
        public IEnumerator PruebaN()
        {
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.LeftArrow));
            jugador = GameObject.Find("Player");
            yield return new WaitForSeconds(0.1f);
            Assert.That(jugador.GetComponent<Rigidbody2D>().velocity.x != 0);

            //Assert.That(sphere.transform.position.y < cube.transform.position.y);
        }

        //Test 4: "salto"
        [UnityTest]
        public IEnumerator PruebaO()
        {
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.UpArrow));
            jugador = GameObject.Find("Player");
            Assert.That(jugador.GetComponent<Rigidbody2D>().velocity.y != 0);
            //Assert.That(sphere.transform.position.y < cube.transform.position.y);
        }

        [UnityTest]
        public IEnumerator PruebaQ()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return new WaitUntil(() => EditorSceneManager.GetActiveScene().name.Equals("Level3"));
            scenes = 6;
            Assert.That(EditorSceneManager.GetActiveScene().name.Equals("Level3"));
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
                case 5:
                    EditorSceneManager.UnloadSceneAsync("Level2");
                    break;
                case 6:
                    EditorSceneManager.UnloadSceneAsync("Level3");
                    break;
            }
        }
        #endregion
    }
}
