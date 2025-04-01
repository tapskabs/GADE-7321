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
   
}
