using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
 
[System.Serializable]
public class DialogueCharacter
{
    public string name;
    public Sprite icon;
}
 
[System.Serializable]
public class DialogueLine
{
    public DialogueCharacter character;
    [TextArea(3, 10)]
    public string line;
}
 
[System.Serializable]
public class Dialogue
{
    public List<DialogueLine> dialogueLines = new List<DialogueLine>();
}
 
public class DialogueHandler : MonoBehaviour
{
    public Button startDialogue;
    public GameObject DialoguePanel;
    public Dialogue dialogue;
 
    public void TriggerDialogue()
    {
        GameManager.instance.dialogBoxOpened = true;
        DialogueController.Instance.StartDialogue(dialogue);
    }
 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            DialoguePanel.SetActive(true);
            startDialogue.onClick.AddListener(TriggerDialogue);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            DialoguePanel.SetActive(false);
        }
    }
}