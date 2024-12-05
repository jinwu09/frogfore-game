using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreExit : MonoBehaviour
{
    [Header("Scene Settings")]
    [SerializeField] string sceneToLoad;
    [SerializeField] string transitionAreaName;
    [SerializeField] AreaEnter theAreaEnter;
    [SerializeField] GameObject EnterButton;

    [Header("Scene Transtition Animation")]
    public Material transitionMaterial;
    [SerializeField] GameObject loadingScreen;
    public float transitionDuration = 1.0f;

    private float transitionProgress = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        theAreaEnter.transitionAreaName = transitionAreaName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            EnterButton.SetActive(true);
        }
        
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            EnterButton.SetActive(false);
        }
    }

    public void TransportScene()
    {
        StartCoroutine(StartSceneTransition(sceneToLoad));
    }
    IEnumerator StartSceneTransition(string sceneToLoad)
    {
        if(transitionMaterial != null)
        {
            float timer = 0.0f;
            while (timer < transitionDuration)
            {
                transitionProgress = 1.0f - (timer / transitionDuration);
                transitionMaterial.SetFloat("_Progress", transitionProgress); // Reverse progress in the shader

                timer += Time.deltaTime;
                yield return null;
            }

            transitionProgress = 1.0f;
            transitionMaterial.SetFloat("_Progress", transitionProgress); // Ensure progress is at 1
        }
        
        if (loadingScreen != null)
        {
            loadingScreen.SetActive(true);
        }

        PlayerController.instance.transitionName = transitionAreaName;
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneToLoad);
    }
}
