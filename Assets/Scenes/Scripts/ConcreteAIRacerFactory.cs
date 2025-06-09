using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcreteAIRacerFactory : AIRacerFactory
{
    public GameObject fastPrefab;
    public GameObject mediumPrefab;
    public GameObject slowPrefab;

    public override GameObject CreateAIRacer(Vector3 position, Transform parent)
    {
        int randomIndex = Random.Range(0, 3);
        GameObject prefabToSpawn = null;
        float speed = 0f;

        switch (randomIndex)
        {
            case 0:
                prefabToSpawn = fastPrefab;
                speed = 6f;
                break;
            case 1:
                prefabToSpawn = mediumPrefab;
                speed = 4f;
                break;
            case 2:
                prefabToSpawn = slowPrefab;
                speed = 2.5f;
                break;
        }

        GameObject racer = Instantiate(prefabToSpawn, position, Quaternion.identity, parent);
        racer.GetComponent<AIRacer>().speed = speed;
        return racer;
    }
}
