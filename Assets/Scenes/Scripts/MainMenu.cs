using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadCheckpointRace()
    {
        SceneManager.LoadScene("CheckpointRaceDialogue");
    }

    public void LoadBeginnerRace()
    {
        SceneManager.LoadScene("BeginnerRaceDialogue");
    }

    public void LoadAdvancedRace()
    {
        SceneManager.LoadScene("AdvancedRaceDialogue");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
}
