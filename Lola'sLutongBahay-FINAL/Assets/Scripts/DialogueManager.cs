using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;

public class DialogueManager : MonoBehaviour
{
    public Text dialogText;
    public Button[] choiceButtons;
    
    private Story story;

    private void Start()
    {
        // Load your Ink story file
        TextAsset inkJSON = Resources.Load<TextAsset>("dialog");
        story = new Story(inkJSON.text);

        // Hide choice buttons initially
        foreach (var button in choiceButtons)
        {
            button.gameObject.SetActive(false);
        }

        // Start the dialog
        AdvanceDialog();
    }

    private void DisplayDialog(string text)
    {
        dialogText.text = text;
    }

    private void DisplayChoices(Choice[] choices)
    {
        for (int i = 0; i < choices.Length; i++)
        {
            choiceButtons[i].gameObject.SetActive(true);
            choiceButtons[i].GetComponentInChildren<Text>().text = choices[i].text;
            int choiceIndex = i; // To capture the current choice index
            choiceButtons[i].onClick.AddListener(() => MakeChoice(choiceIndex));
        }
    }

    private void MakeChoice(int choiceIndex)
    {
        story.ChooseChoiceIndex(choiceIndex);
        AdvanceDialog();
    }

    private void AdvanceDialog()
    {
        // Clear previous choices
        foreach (var button in choiceButtons)
        {
            button.onClick.RemoveAllListeners();
            button.gameObject.SetActive(false);
        }

        // Continue the Ink story
        if (story.canContinue)
        {
            string text = story.Continue();
            DisplayDialog(text);
        }
        else if (story.currentChoices.Count > 0)
        {
            Choice[] choices = story.currentChoices.ToArray();
            DisplayChoices(choices);
        }
        else
        {
            // End of the story
            Debug.Log("End of dialog.");
        }
    }
}
