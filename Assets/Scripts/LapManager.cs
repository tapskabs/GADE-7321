using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LapManager : MonoBehaviour
{
    public int currentLap = 0;
    public int totalLaps = 3;
    private bool hasEntered = false;

    public TextMeshProUGUI lapText; // Now using TextMeshPro

    public GameObject raceEndPanel; // Optional end screen

    void Start()
    {
        if (lapText != null)
            lapText.text = "Lap: " + currentLap + "/" + totalLaps;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LapTrigger") && !hasEntered)
        {
            hasEntered = true;
            currentLap++;

            Debug.Log("Lap: " + currentLap);
            if (lapText != null)
                lapText.text = "Lap: " + currentLap + "/" + totalLaps;

            if (currentLap >= totalLaps)
                EndRace();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("LapTrigger"))
        {
            hasEntered = false;
        }
    }

    void EndRace()
    {
        Debug.Log("Race Finished!");
        if (raceEndPanel != null)
            raceEndPanel.SetActive(true);
    }
}
