using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CheckpointManager : MonoBehaviour
{
    public GameObject player;  // The tiger racer
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI checkpointStatusText;
    public float raceTime = 60f;  // Initial countdown timer
    private CheckpointStack<GameObject> checkpointStack = new CheckpointStack<GameObject>();

    private float timer;
    private bool raceOver = false;

    void Start()
    {
        timer = raceTime;
        GameObject[] checkpoints = GameObject.FindGameObjectsWithTag("Checkpoint");

        // Push all checkpoints onto the stack (reverse order if needed)
        foreach (GameObject checkpoint in checkpoints)
        {
            checkpointStack.Push(checkpoint);
            checkpoint.GetComponent<Renderer>().material.color = Color.red; // Unvisited
        }

        UpdateUI();
        StartCoroutine(CountdownTimer());
    }

    void UpdateUI()
    {
        timerText.text = "Time Left: " + Mathf.Ceil(timer) + "s";
        checkpointStatusText.text = "Checkpoints Left: " + checkpointStack.Count();
    }

    IEnumerator CountdownTimer()
    {
        while (timer > 0 && !raceOver)
        {
            yield return new WaitForSeconds(1);
            timer -= 1;
            UpdateUI();

            if (timer <= 0)
            {
                GameOver(false);
            }
        }
    }

    public void CheckpointReached(GameObject checkpoint)
    {
        if (checkpointStack.IsEmpty() || checkpoint != checkpointStack.Peek())
        {
            return;  // Ignore if it's not the next target checkpoint
        }

        checkpointStack.Pop();
        checkpoint.GetComponent<Renderer>().material.color = Color.green;  // Mark as visited
        Destroy(checkpoint, 0.5f); // Remove checkpoint after 0.5s
        timer += 5; // Add 5 seconds
        UpdateUI();

        if (checkpointStack.IsEmpty())
        {
            GameOver(true);
        }
    }

    void GameOver(bool won)
    {
        raceOver = true;
        StopAllCoroutines();
        timerText.text = won ? "YOU WIN!" : "TIME'S UP! YOU LOSE!";
    }
}
