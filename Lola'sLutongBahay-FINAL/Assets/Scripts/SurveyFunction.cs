using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurveyFunction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AnswerSurvey(string surveyUrl)
    {
        Application.OpenURL(surveyUrl);
    }


    public void OpenBrowser(string urlToOpen)
    {
        // Create a URI from the provided URL
        string uri = Uri.EscapeUriString(urlToOpen);

        // Construct the intent to open the browser
        AndroidJavaClass uriClass = new AndroidJavaClass("android.net.Uri");
        AndroidJavaObject uriObject = uriClass.CallStatic<AndroidJavaObject>("parse", uri);

        AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent");
        AndroidJavaObject intentObject = new AndroidJavaObject("android.content.Intent", intentClass.GetStatic<string>("ACTION_VIEW"), uriObject);

        // Get the current activity
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

        // Start the activity
        currentActivity.Call("startActivity", intentObject);
    }
}
