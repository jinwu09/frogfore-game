using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class OmeletGameManager : MonoBehaviour
{
    // Singleton instance
    private static OmeletGameManager instance;

    // Private constructor to prevent instantiation from other scripts
    private OmeletGameManager() { }

    public Animator transitionAnim;
    [SerializeField] GameObject StageOneUI;
    [SerializeField] GameObject StageTwoUI;
    [SerializeField] GameObject StageThreeUI;
    [SerializeField] GameObject VictoryUI;
    [SerializeField] RecipeManager ManageUI;
    [SerializeField] GameObject NextButton;


    // Public static method to access the singleton instance
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public static OmeletGameManager Instance
    {
        get
        {
            // If the instance is null, find the existing OmeletGameManager in the scene or create a new one if none exists
            if (instance == null)
            {
                instance = FindObjectOfType<OmeletGameManager>();

                if (instance == null)
                {
                    GameObject singletonObject = new GameObject();
                    instance = singletonObject.AddComponent<OmeletGameManager>();
                    singletonObject.name = "OmeletGameManager";
                }
            }

            return instance;
        }
    }

    // Methods representing different states of the game
    public void StageOne()
    {
        StageOneUI.SetActive(true);
    }

    public void StageTwo()
    {
        StageOneUI.SetActive(false);
        StageTwoUI.SetActive(true);
    }

    public void StageThree()
    {
        StageThreeUI.SetActive(true);
    }

    public void Victory()
    {
        VictoryUI.SetActive(true);
    }

    // Optional: You can add other methods or variables as needed for your game

    // Optional: Ensure the instance is not destroyed when loading a new scene
    // Make sure to comment this out if you want the OmeletGameManager to reset when loading a new scene.
    
    private void NextLevel()
    {
        StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel()
    {
        transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(1);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        transitionAnim.SetTrigger("Start");
    }

    private void Update()
    {
        
    }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
