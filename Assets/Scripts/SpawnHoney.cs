using UnityEngine;

public class SpawnHoney : MonoBehaviour
{
    public GameObject honeyPrefab;
    public GameObject beekeeper;
    private bool hasSpawned = false;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == beekeeper && !hasSpawned)
        {
            Debug.Log("Collision with beekeeper detected.");
            GameObject honey = Instantiate(honeyPrefab);
            honey.tag = "Honey";
            Debug.Log("Honey prefab instantiated: " + honey.name);
            hasSpawned = true;
        }
    }
}