using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RaceManager : MonoBehaviour
{
    public TextMeshProUGUI positionText; // Assign in Inspector
    private List<GameObject> allRacers;
    private GameObject player;

    void Start()
    {
        allRacers = new List<GameObject>();

        // Get AI Racers
        GameObject[] aiRacers = GameObject.FindGameObjectsWithTag("Racer");
        allRacers.AddRange(aiRacers);

        // Get Player
        player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            allRacers.Add(player);
        }
    }

    void Update()
    {
        allRacers.Sort(CompareRacers);
        int playerPosition = allRacers.IndexOf(player) + 1;
        positionText.text = playerPosition + GetPositionSuffix(playerPosition);
    }

    // Compare based on waypoints passed, then distance to next waypoint
    private int CompareRacers(GameObject a, GameObject b)
    {
        RacerProgress progressA = a.GetComponent<RacerProgress>();
        RacerProgress progressB = b.GetComponent<RacerProgress>();

        if (progressA.waypointsPassed != progressB.waypointsPassed)
            return progressB.waypointsPassed.CompareTo(progressA.waypointsPassed); // Higher is better

        float distA = Vector3.Distance(a.transform.position, progressA.nextWaypoint.position);
        float distB = Vector3.Distance(b.transform.position, progressB.nextWaypoint.position);
        return distA.CompareTo(distB); // Closer is better
    }

    private string GetPositionSuffix(int pos)
    {
        if (pos % 10 == 1 && pos != 11) return "st";
        if (pos % 10 == 2 && pos != 12) return "nd";
        if (pos % 10 == 3 && pos != 13) return "rd";
        return "th";
    }
}
