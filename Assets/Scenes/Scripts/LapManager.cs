using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class LapManager : MonoBehaviour
{
    public int currentLap = 0;
    public int totalLaps = 3;
    private bool hasEntered = false;

    public TextMeshProUGUI lapText;
    public GameObject raceEndPanel;

    public List<Animator> spectatorAnimators; // Drag in spectators here

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

        // Trigger victory animation for all spectators
        foreach (Animator anim in spectatorAnimators)
        {
            if (anim != null)
                anim.SetTrigger("Victory");
        }

        if (raceEndPanel != null)
            raceEndPanel.SetActive(true);
    }
}
