using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIRacerFactory : MonoBehaviour
{
    public abstract GameObject CreateAIRacer(Vector3 position, Transform parent);
}
