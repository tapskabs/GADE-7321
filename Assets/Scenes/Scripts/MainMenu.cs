using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadCheckpointRace()
    {
        SFXManager.Instance.PlaySFX("click");
        SceneManager.LoadScene("CheckpointRaceDialogue");
    }

    public void LoadBeginnerRace()
    {
        SFXManager.Instance.PlaySFX("click");
        SceneManager.LoadScene("BeginnerRaceDialogue");
    }

    public void LoadAdvancedRace()
    {
        SFXManager.Instance.PlaySFX("click");
        SceneManager.LoadScene("AdvancedRaceDialogue");
    }

    public void QuitGame()
    {
        SFXManager.Instance.PlaySFX("click");
        Debug.Log("Quitting Game...");
        Application.Quit();
    }

   
}
