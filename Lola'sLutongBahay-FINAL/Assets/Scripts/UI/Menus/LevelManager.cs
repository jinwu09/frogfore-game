using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelManager : MonoBehaviour
{
    [SerializeField] string sceneNameToLoad;
    public TextMeshProUGUI timerText;

    private float levelStartTime;
    private bool levelEnded = false;
    
    // Start is called before the first frame update
    
    void Start()
    {
        levelStartTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (!levelEnded)
        {
            // Calculate the remaining time.
            float timeRemaining = Mathf.Max(0, 120 - (Time.time - levelStartTime));

            // Format the time as "mm:ss".
            string minutes = Mathf.Floor(timeRemaining / 60).ToString("00");
            string seconds = (timeRemaining % 60).ToString("00");

            // Update the timer text.
            timerText.text = minutes + ":" + seconds;

            if (timeRemaining <= 0)
            {
                // Time is up, trigger the level end function.
                LevelEnd();
            }
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(sceneNameToLoad);
    }

    public void ExitLevel()
    {
        SceneManager.LoadScene("RPG-House");
    }
    public void LevelEnd()
    {
        levelEnded = true;
    }

    public void LoadCooking(string SceneToLoad) 
    {
        SceneManager.LoadScene(SceneToLoad);
    }

    public void ClaimXP(int amountOfXp)
    {
        PlayerStats playerStats = GameObject.FindObjectOfType<PlayerStats>();
        if (playerStats != null)
        {
            playerStats.AddXp(amountOfXp);
        }
    }

    public void ClaimCoin(int amountofCoin)
    {
        GameManager.instance.currentBitcoins += (int)(amountofCoin);
    }

    public void CompleteTask(string taskName)
    {
        TaskManager taskManager = GameObject.FindObjectOfType<TaskManager>();
        Task task = taskManager.GetTask(taskName);
        if (task != null)
        {
            task.MarkAsComplete();
        }
    }

}
