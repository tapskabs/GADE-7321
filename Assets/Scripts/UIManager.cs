using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI lapText;
    public TextMeshProUGUI positionText;
    public GameObject endScreenPanel;
    public TextMeshProUGUI endScreenText;
    private List<RacerProgressTracker> racers;
    private RacerProgressTracker playerTracker;

    public static UIManager Instance;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        racers = FindObjectsOfType<RacerProgressTracker>().ToList();
        playerTracker = racers.FirstOrDefault(r => r.isPlayer);
    }

    public void UpdateLapText(int currentLap, int totalLaps)
    {
        lapText.text = $"Lap {currentLap}/{totalLaps}";
    }

    public void UpdatePositionAndLap()
    {
        racers = FindObjectsOfType<RacerProgressTracker>().ToList();

        racers.Sort((a, b) =>
        {
            int wpCompare = b.waypointsPassed.CompareTo(a.waypointsPassed);
            if (wpCompare != 0) return wpCompare;

            //float aDist = Vector3.Distance(a.transform.position, a.GetComponent<AdvancedAIRacer>()?.GetNextWaypoint() ?? Vector3.zero);
            // Replace this line:
           // float aDist = Vector3.Distance(a.transform.position, a.GetComponent<AdvancedAIRacer>()?.GetNextWaypoint() ?? Vector3.zero);

            // With this line, using the GetNextWaypoint() from AdvancedRacerTracker (the base class):
            float aDist = Vector3.Distance(a.transform.position, a.GetComponent<AdvancedRacerTracker>()?.GetNextWaypoint() ?? Vector3.zero);
            float bDist = Vector3.Distance(b.transform.position, b.GetComponent<AdvancedRacerTracker>()?.GetNextWaypoint() ?? Vector3.zero);
            return aDist.CompareTo(bDist);
        });

        int position = racers.IndexOf(playerTracker) + 1;
        positionText.text = GetOrdinal(position);
    }

    private string GetOrdinal(int num)
    {
        if (num <= 0) return "";
        if (num % 100 >= 11 && num % 100 <= 13) return num + "th";
        switch (num % 10)
        {
            case 1: return num + "st";
            case 2: return num + "nd";
            case 3: return num + "rd";
            default: return num + "th";
        }
    }
    public int GetPlayerPosition()
    {
        racers = FindObjectsOfType<RacerProgressTracker>().ToList();

        racers.Sort((a, b) =>
        {
            int wpCompare = b.waypointsPassed.CompareTo(a.waypointsPassed);
            if (wpCompare != 0) return wpCompare;

            float aDist = Vector3.Distance(a.transform.position, a.GetComponent<AdvancedRacerTracker>()?.GetNextWaypoint() ?? Vector3.zero);
            float bDist = Vector3.Distance(b.transform.position, b.GetComponent<AdvancedRacerTracker>()?.GetNextWaypoint() ?? Vector3.zero);
            return aDist.CompareTo(bDist);
        });

        return racers.IndexOf(playerTracker) + 1;
    }
    public void EndRace(bool playerFinished)
    {
        int playerPosition = racers.IndexOf(playerTracker) + 1;

        endScreenPanel.SetActive(true);

        if (playerPosition == 1 && playerFinished)
            endScreenText.text = "You Won!";
        else
            endScreenText.text = "You Lost!";
        foreach (var racer in racers)
        {
            if (racer.TryGetComponent<AdvancedAIRacer>(out var ai))
                ai.enabled = false;

            if (racer.isPlayer)
                racer.GetComponent<RacingPlayerController>().enabled = false;
        }
        SFXManager.Instance.PlaySFX("raceEnd");
    }

}
