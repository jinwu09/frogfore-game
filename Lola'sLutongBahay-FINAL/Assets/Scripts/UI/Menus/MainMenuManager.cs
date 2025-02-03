using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Net.NetworkInformation;

public class MainMenuManager : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;

    public void LoadLevel(int sceneToLoad)
    {
        StartCoroutine(LoadAsynchronously(sceneToLoad));
    }

    IEnumerator LoadAsynchronously(int sceneToLoad)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneToLoad);
        operation.allowSceneActivation = false;
        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {


            slider.value = Mathf.Clamp01(operation.progress / .9f);

            if (operation.progress >= 0.9f)
            {
                loadingScreen.transform.GetChild(3).gameObject.SetActive(true);
                loadingScreen.transform.GetChild(1).gameObject.SetActive(false);
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    operation.allowSceneActivation = true;
                }
            }

            yield return null;
        }
    }

    public void CloseGame()
    {
        // Quit the application (works in standalone builds, not in the Unity Editor)
        Application.Quit();
    }
}
