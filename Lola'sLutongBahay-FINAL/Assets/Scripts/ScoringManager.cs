using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoringManager : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI restartCountText;
    public int restartCount;
    // Start is called before the first frame update
    void Start()
    {
        FindUITextReferences();
        UpdateRestartCountText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateRestartCountText()
    {
        if (restartCountText != null)
            restartCountText.text = "Restarts: " + restartCount;
    }

    void FindUITextReferences()
    {
        // Find the UI Text components in the current scene.
        GameObject timerObject = GameObject.Find("TimerText");
        GameObject restartCountObject = GameObject.Find("RestartCountText");

        if (timerObject != null)
            timerText = timerObject.GetComponent<TextMeshProUGUI>();

        if (restartCountObject != null)
            restartCountText = restartCountObject.GetComponent<TextMeshProUGUI>();
    }
}
