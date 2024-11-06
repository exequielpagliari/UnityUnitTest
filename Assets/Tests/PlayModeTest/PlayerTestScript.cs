/*
using System.Collections;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
public class PlayerTestScript
{
    [OneTimeSetUp]
    public void LoadScene()
    {
        SceneManager.LoadScene("Assets\\Scenes\\SampleScene.unity");
    }


    [UnityTest]
    public IEnumerator
    GameObject_WithRigidBody_WillBeAffectedByPhysics()
    {
        yield return new WaitForSeconds(1f);
        var gameObject = GameObject.Find("Sphere");

        Assert.That(gameObject, Is.Not.Null);
        /*
        // Arrange
        var go = new GameObject();
        go.AddComponent<Rigidbody>();
        var originalPosition = go.transform.position.y;
        // Act
        yield return new WaitForFixedUpdate();
        // Assert
        Assert.AreNotEqual(originalPosition,
        go.transform.position.y);

        yield return null;
    }
}
*/

using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace ValidationTests
{
    [TestFixture]
    [TestFixtureSource(typeof(GameplayScenesProvider))]
    public class SceneValidationTests
    {
        private readonly string _scenePath;

        public SceneValidationTests(string scenePath)
        {
            _scenePath = scenePath;
        }

        [OneTimeSetUp]
        public void LoadScene()
        {
            SceneManager.LoadScene(_scenePath);
        }

        [UnityTest]
        public IEnumerator Player()
        {
            yield return waitForSceneLoad();
            yield return new WaitForSeconds(1f);
            var gameObject = GameObject.Find("Sphere");

            Assert.That(gameObject, Is.Not.Null);
        }
        [UnityTest]
        public IEnumerator PlayerMoveRigth()
        {
            yield return null;

            var gameObject = GameObject.Find("Sphere");
            var position = gameObject.transform.position;
            gameObject.GetComponent<PlayerController>().AddVelocity(Vector3.left);
            yield return new WaitForSeconds(.125f);
            Assert.AreNotEqual(position.x, gameObject.transform.position.x);
        }

        IEnumerator waitForSceneLoad()
        {
            while (!SceneManager.GetActiveScene().isLoaded)
            {
                yield return null;
            }
        }
    }

    public class GameplayScenesProvider : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            foreach (var scene in EditorBuildSettings.scenes)
            {
                if (!scene.enabled || scene.path == null)
                {
                    continue;
                }

                yield return scene.path;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
