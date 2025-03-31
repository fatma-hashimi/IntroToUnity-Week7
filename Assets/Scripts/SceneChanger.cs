using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string nextSceneName;

    public void onBeekeeperOneChoice()
    {
        BeekeeperChoice.choice = "BeekeeperOne";
        ChangeScene(nextSceneName);
    }

    public void onBeekeeperTwoChoice()
    {
        BeekeeperChoice.choice = "BeekeeperTwo";
        ChangeScene(nextSceneName);
    }

    public void ChangeScene(string newScene)
    {
        Debug.Log("Changing to: " + newScene);
        SceneManager.LoadScene(newScene);
    }
}
