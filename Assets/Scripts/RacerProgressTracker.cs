using System.Collections.Generic;
using UnityEngine;

public class RacerProgressTracker : MonoBehaviour
{
    public int waypointsPassed = 0;
    public int currentLap = 1;
    public int totalLaps = 3;

    private HashSet<Transform> visitedThisLap = new HashSet<Transform>();
    public bool isPlayer = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AdvancedWaypoint"))
        {
            Transform waypoint = other.transform;

            if (!visitedThisLap.Contains(waypoint))
            {
                visitedThisLap.Add(waypoint);
                waypointsPassed++;

                if (isPlayer)
                    UIManager.Instance.UpdatePositionAndLap();

                if (visitedThisLap.Count >= 11)
                {
                    currentLap++;
                    visitedThisLap.Clear();

                    if (isPlayer)
                    {
                        UIManager.Instance.UpdateLapText(currentLap, totalLaps);
                        SFXManager.Instance.PlaySFX("lapComplete");

                        if (currentLap > totalLaps)
                        {
                            UIManager.Instance.EndRace(true); // Player completed all laps
                        }
                    }
                }
            }
        }
    }

}

