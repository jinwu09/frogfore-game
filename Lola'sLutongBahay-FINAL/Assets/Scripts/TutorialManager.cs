using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // Add this line for TextMesh Pro
using UnityEngine.Events;

[System.Serializable]
public class TutorialStep
{
    public string dialogText;
    public Sprite reactionImage;
}

public class TutorialManager : MonoBehaviour
{
    public GameObject dialogPanel;
    public TextMeshProUGUI dialogText; // Change to TextMeshProUGUI
    public Image reactionImage;

    public TutorialStep[] tutorialSteps;
    private int currentStepIndex = 0;

    private string currentDialog;
    private int currentCharIndex = 0;
    private bool isAnimatingText = false;

    public float textAnimationSpeed = 30f; // Characters per second

    [SerializeField] UnityEvent actionEvent;

    private void Start()
    {
        dialogText.text = "";
        UpdateTutorialStep();
    }

    private void UpdateTutorialStep()
    {
        if (currentStepIndex < tutorialSteps.Length)
        {
            TutorialStep currentStep = tutorialSteps[currentStepIndex];

            currentDialog = currentStep.dialogText;
            reactionImage.sprite = currentStep.reactionImage;

            // Show the dialog panel
            dialogPanel.SetActive(true);

            // Start the text animation
            StartCoroutine(AnimateText());
        }
        else
        {
            // End of tutorial
            // You can perform some action or load a new scene here
            dialogPanel.SetActive(false);
        }
    }

    private IEnumerator AnimateText()
    {
        isAnimatingText = true;
        currentCharIndex = 0;
        dialogText.text = "";

        while (currentCharIndex < currentDialog.Length)
        {
            dialogText.text += currentDialog[currentCharIndex];
            currentCharIndex++;
            yield return new WaitForSeconds(1f / textAnimationSpeed);
        }

        isAnimatingText = false;
    }

    private void Update()
    {
        if (isAnimatingText)
        {
            // If text is still animating, allow the player to skip by clicking
            if (Input.GetMouseButtonDown(0))
            {
                StopCoroutine(AnimateText());
                dialogText.text = currentDialog; // Show the entire text
                isAnimatingText = false;
            }
        }
        else if (Input.GetMouseButtonDown(0))
        {
            if (currentStepIndex < tutorialSteps.Length - 1)
            {
                currentStepIndex++;
                UpdateTutorialStep();
            }
            else
            {
                // End of tutorial
                // You can perform some action or load a new scene here
                dialogPanel.SetActive(false);
                actionEvent.Invoke();
            }
        }
    }
}
