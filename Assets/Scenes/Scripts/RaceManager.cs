using System.Linq;
using TMPro;
using UnityEngine;

public class RaceManager : MonoBehaviour
{
    public RacerProgress[] racers;
    public RacerProgress player;
    public TextMeshProUGUI positionText;

    void Start()
    {
        racers = FindObjectsOfType<RacerProgress>();
    }

    void Update()
    {
        foreach (var racer in racers)
        {
            racer.UpdateDistance();
        }

        var ranked = racers.OrderByDescending(r => r.checkpointsPassed)
                           .ThenBy(r => r.distanceToNext)
                           .ToList();

        int position = ranked.IndexOf(player) + 1;
        positionText.text = GetOrdinal(position) + " Place";
    }

    private string GetOrdinal(int number)
    {
        if (number <= 0) return number.ToString();
        if (number % 100 >= 11 && number % 100 <= 13) return number + "th";

        switch (number % 10)
        {
            case 1: return number + "st";
            case 2: return number + "nd";
            case 3: return number + "rd";
            default: return number + "th";
        }
    }
}
