using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject beekeeperOne;
    public GameObject beekeeperTwo;

    void Start()
    {
        DisplayKeeper();
    }

    void DisplayKeeper()
    {
        switch (BeekeeperChoice.choice)
        {
            case "BeekeeperOne":
                beekeeperOne.SetActive(true);
                beekeeperTwo.SetActive(false);
                break;
            case "BeekeeperTwo":
                beekeeperOne.SetActive(false);
                beekeeperTwo.SetActive(true);
                break;
            default:
                beekeeperOne.SetActive(false);
                beekeeperTwo.SetActive(false);
                break;
        }

       
    }

    void Update()
    {
        
    }
}