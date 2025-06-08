using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;

public class AdvancedRaceUI : MonoBehaviour
{
    public TextMeshProUGUI positionText;
    public TextMeshProUGUI lapText;

    private AdvancedRacerTracker[] trackers;

    void Start()
    {
        trackers = FindObjectsOfType<AdvancedRacerTracker>();
    }

    void Update()
    {
        List<AdvancedRacerTracker> sorted = trackers.OrderByDescending(t => t.waypointsPassed)
                                                    .ThenBy(t => t.DistanceToNext()).ToList();

        int playerIndex = sorted.FindIndex(t => t.racerID == 0);
        string suffix = GetSuffix(playerIndex + 1);

        positionText.text = $"{playerIndex + 1}{suffix}";
        lapText.text = $"Lap {sorted[playerIndex].lap}/3";
    }

    string GetSuffix(int number)
    {
        if (number % 100 >= 11 && number % 100 <= 13) return "th";
        switch (number % 10)
        {
            case 1: return "st";
            case 2: return "nd";
            case 3: return "rd";
            default: return "th";
        }
    }
}
