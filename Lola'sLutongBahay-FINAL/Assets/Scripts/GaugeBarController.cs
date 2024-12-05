using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GaugeBarController : MonoBehaviour
{
    [Header("Managers")]
    public RecipeManager recipeManager;
    public ServingManager servingManager;
    public string actionName;
    public Slider gaugeSlider;
    public Button successButton;
    public GameObject loseEvent;
    public UnityEvent winEvent;

    private bool isGameOver = true;

    private void Start()
    {
        successButton.onClick.AddListener(CheckSuccess);
    }

    public void StartCounting()
    {
        isGameOver = false;
    }

    private void Update()
    {
        if (!isGameOver)
        {
            gaugeSlider.value += Time.deltaTime * 0.5f; // Adjust the speed of gauge movement here

            if (gaugeSlider.value >= 5.0f)
            {
                // If the gauge reaches the end without clicking, invoke the lose event.
                isGameOver = true;
                loseEvent.SetActive(true);
            }
        }
    }

    private void CheckSuccess()
    {
        if (gaugeSlider.value >= 3.42f && gaugeSlider.value <= 4f)
        {
            // If the player clicks within the specified range, invoke the success event.
            if (servingManager == null) {
                    recipeManager.playerActions.Add(actionName);
                    string result = recipeManager.CheckSequence();
            }
            else {
                    servingManager.playerActions.Add(actionName);
                    string result = servingManager.CheckSequence();
            }
            isGameOver = true;
            Debug.Log("Success!");
            winEvent.Invoke();
        }
        else
        {
            // If the player clicks outside the specified range, invoke the lose event.
            isGameOver = true;
            loseEvent.SetActive(true);
        }
    }
}
