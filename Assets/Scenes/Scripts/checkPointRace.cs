using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class StackADT<T>
{
    private List<T> items = new List<T>();

    public void Push(T item)
    {
        items.Add(item);
    }

    public T Pop()
    {
        if (IsEmpty()) throw new InvalidOperationException("Stack is empty");
        T item = items[items.Count - 1];
        items.RemoveAt(items.Count - 1);
        return item;
    }

    public T Peek()
    {
        if (IsEmpty()) throw new InvalidOperationException("Stack is empty");
        return items[items.Count - 1];
    }

    public bool IsEmpty()
    {
        return items.Count == 0;
    }
}
public class checkPointRace : MonoBehaviour
{
    public StackADT<GameObject> checkpointStack = new StackADT<GameObject>();
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI raceStatusText;
    public float timeLeft = 60f;
    public float timeBonus = 5f;
    private bool raceOver = false;

    void Start()
    {
        
        GameObject[] checkpoints = GameObject.FindGameObjectsWithTag("Checkpoint");
        Array.Reverse(checkpoints); 
        foreach (GameObject checkpoint in checkpoints)
        {
            checkpointStack.Push(checkpoint);
            SetCheckpointColor(checkpoint, Color.red); 
        }
    }

    void Update()
    {
        if (!raceOver)
        {
            timeLeft -= Time.deltaTime;
            timerText.text = "Time: " + Mathf.Ceil(timeLeft); 

            if (timeLeft <= 0)
            {
                EndRace(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Checkpoint") && !checkpointStack.IsEmpty())
        {
            GameObject currentCheckpoint = checkpointStack.Peek(); 

            if (currentCheckpoint == other.gameObject)
            {
                checkpointStack.Pop(); 
                SetCheckpointColor(other.gameObject, Color.green); 
                timeLeft += timeBonus; 

                if (checkpointStack.IsEmpty())
                {
                    EndRace(true); 
                }
            }
        }
    }

    private void SetCheckpointColor(GameObject checkpoint, Color color)
    {
        Renderer renderer = checkpoint.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = color;
        }
    }

    private void EndRace(bool won)
    {
        raceOver = true;
        raceStatusText.text = won ? "You Win! All checkpoints reached!" : "You Lose! Timer ran out!";
    }


}
