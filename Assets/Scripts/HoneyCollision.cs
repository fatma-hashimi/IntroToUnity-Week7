using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class HoneyCollision : MonoBehaviour
{
    private GameObject goalBox;
    private TextMeshProUGUI scoreText;
    private int score = 0;

    void Start()
    {
        goalBox = GameObject.FindWithTag("GoalBox");
        scoreText = GameObject.FindWithTag("ScoreText").GetComponent<TextMeshProUGUI>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == goalBox)
        {
            Debug.Log("Honey collided with: " + gameObject.name);
            score++;
            UpdateScoreText();
            Destroy(gameObject);
            if (score == 3)
            {
                ChangeScene("WinScreen");
            }
        }
    }

    void UpdateScoreText()
    {
        scoreText.text = "Collected honey: " + score + "/3";
    }

    void ChangeScene(string newScene)
    {
        Debug.Log("Changing to: " + newScene);
        SceneManager.LoadScene(newScene);
    }
}