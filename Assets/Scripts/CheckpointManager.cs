using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CheckpointManager : MonoBehaviour
{
    public GameObject player;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI checkpointStatusText;
    public float raceTime = 60f;
    private CheckpointStack<GameObject> checkpointStack = new CheckpointStack<GameObject>();

    private float timer;
    private bool raceOver = false;

    void Start()
    {
        timer = raceTime;
        GameObject[] checkpoints = GameObject.FindGameObjectsWithTag("Checkpoint");

       
        for (int i = checkpoints.Length - 1; i >= 0; i--)  
        {
            checkpointStack.Push(checkpoints[i]);
            checkpoints[i].GetComponent<Renderer>().material.color = Color.red; 
        }

        UpdateTargetCheckpoint(); 
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
            return;  
        }

        checkpointStack.Pop();
        checkpoint.GetComponent<Renderer>().material.color = Color.green;
        Destroy(checkpoint, 0.5f);
        timer += 5;
        UpdateTargetCheckpoint(); 
        UpdateUI();

        if (checkpointStack.IsEmpty())
        {
            GameOver(true);
        }
    }

    void UpdateTargetCheckpoint()
    {
        if (!checkpointStack.IsEmpty())
        {
            GameObject nextCheckpoint = checkpointStack.Peek();
            nextCheckpoint.GetComponent<Renderer>().material.color = Color.magenta; 
        }
    }

    void GameOver(bool won)
    {
        raceOver = true;
        StopAllCoroutines();
        timerText.text = won ? "YOU WIN!" : "TIME'S UP! YOU LOSE!";
    }
}
