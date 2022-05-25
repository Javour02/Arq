using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor.SceneManagement;

namespace Test.Jugador {

    public class Jugador
    {
        //Definición de las referencias para la prueba
        #region FIELDS

        private GameObject jugador;
        private GameObject square;
        #endregion

        #region TESTS

        //Todo lo que ocurre antes del test
        [SetUp]
        public void SetUp()
        {
            EditorSceneManager.LoadScene("Level1");
            
        }

        //Test 1: "Colision con el suelo"
        [UnityTest]
        public IEnumerator PruebaA()
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
        public IEnumerator PruebaB()
        {
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.RightArrow));
            jugador = GameObject.Find("Player");
            Assert.That(jugador.GetComponent<Rigidbody2D>().velocity.x != 0);

            //Assert.That(sphere.transform.position.y < cube.transform.position.y);
        }

        //Test 3: "Movimiento a la izquierda"
        [UnityTest]
        public IEnumerator PruebaC()
        {
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.LeftArrow));
            jugador = GameObject.Find("Player");
            yield return new WaitForSeconds(0.1f);
            Assert.That(jugador.GetComponent<Rigidbody2D>().velocity.x != 0);

            //Assert.That(sphere.transform.position.y < cube.transform.position.y);
        }

        //Test 4: "salto"
        [UnityTest]
        public IEnumerator PruebaD()
        {
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.UpArrow));
            jugador = GameObject.Find("Player");
            Assert.That(jugador.GetComponent<Rigidbody2D>().velocity.y != 0);
            //Assert.That(sphere.transform.position.y < cube.transform.position.y);
        }

        [TearDown]
        public void TearDown()
        {
            EditorSceneManager.UnloadSceneAsync("Level1");
        }
        #endregion
    }
}