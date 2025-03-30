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
        // Find all checkpoints and add them in the correct order
        GameObject[] checkpoints = GameObject.FindGameObjectsWithTag("Checkpoint");
        Array.Reverse(checkpoints); // Ensure the first checkpoint is at the top of the stack

        foreach (GameObject checkpoint in checkpoints)
        {
            checkpointStack.Push(checkpoint);
            SetCheckpointColor(checkpoint, Color.red); // Set all checkpoints to red initially
        }
    }

    void Update()
    {
        if (!raceOver)
        {
            timeLeft -= Time.deltaTime;
            timerText.text = "Time: " + Mathf.Ceil(timeLeft); // Display time rounded up

            if (timeLeft <= 0)
            {
                EndRace(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Ensure only the player triggers checkpoints
        if (other.CompareTag("Checkpoint") && !checkpointStack.IsEmpty())
        {
            GameObject currentCheckpoint = checkpointStack.Peek(); // Get the next target checkpoint

            if (currentCheckpoint == other.gameObject)
            {
                checkpointStack.Pop(); // Remove it from the stack
                SetCheckpointColor(other.gameObject, Color.green); // Turn checkpoint green
                timeLeft += timeBonus; // Add 5 seconds to timer

                if (checkpointStack.IsEmpty())
                {
                    EndRace(true); // End race if all checkpoints are reached
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
