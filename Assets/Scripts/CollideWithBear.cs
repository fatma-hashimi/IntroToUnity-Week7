using UnityEngine;
using UnityEngine.SceneManagement;

public class CollideWithBear : MonoBehaviour
{
    public GameObject beekeeper;
    public string nextSceneName;

    void Start()
    {
        beekeeper = GameObject.FindWithTag("Player");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name);

        if (collision.gameObject == beekeeper)
        {
            Debug.Log("Collision with beekeeper detected.");
            ChangeScene(nextSceneName);
        }
    }

    public void ChangeScene(string newScene)
    {
        Debug.Log("Changing to: " + newScene);
        SceneManager.LoadScene(newScene);
    }
}
