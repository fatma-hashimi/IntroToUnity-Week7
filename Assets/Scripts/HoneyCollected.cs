using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class HoneyCollected : MonoBehaviour
{
    public GameObject goalBox;
    public string nextSceneName;
    // private int pointCounter = 0;
    private List<GameObject> honeyObjects = new List<GameObject>();
    private bool honeySpawned = false;

    void Update()
    {
        // added honeySpawned bool to make prevent LoadNextScene(); before honey spawns
        if (honeySpawned && honeyObjects.TrueForAll(honey => honey == null))
        {
            LoadNextScene();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name);

        if (collision.gameObject == goalBox)
        {
            Debug.Log("Collision with goalBox detected.");
            foreach (var honey in honeyObjects)
            {
                if (collision.collider.gameObject == honey)
                {
                    Debug.Log("Collision with honey object detected: " + honey.name);
                    DestroyHoney(honey);
                    break;
                }
            }
        }
    }

    public void AddHoney(GameObject honey)
    {
        honeyObjects.Add(honey);
        honeySpawned = true;
        Debug.Log("Honey added: " + honey.name);
    }

    public void DestroyHoney(GameObject honey)
    {
        honeyObjects.Remove(honey);
        Destroy(honey);
        // pointCounter++;
        // Debug.Log("Point Counter: " + pointCounter);
    }

    void LoadNextScene()
    {
        Debug.Log("Loading next scene: " + nextSceneName);
        SceneManager.LoadScene(nextSceneName);
    }
}