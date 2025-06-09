using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIRacerSpawner : MonoBehaviour
{
    public ConcreteAIRacerFactory racerFactory;
    public Transform[] spawnPoints; // Assign 8+ spawn positions in Inspector

    void Start()
    {
        foreach (Transform spawn in spawnPoints)
        {
            racerFactory.CreateAIRacer(spawn.position, transform);
        }
    }

}
