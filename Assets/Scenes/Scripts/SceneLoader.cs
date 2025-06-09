using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void LoadCheckPointRace()
    {
        SceneManager.LoadScene("CheckpointRace");
    }
    public void BeginnerRace()
    {
        SceneManager.LoadScene("BeginnerRace");
    }
    public void AdvancedRace()
    {
        SceneManager.LoadScene("AdvancedRace");
    }

}
