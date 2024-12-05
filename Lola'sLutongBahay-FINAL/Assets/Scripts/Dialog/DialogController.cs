using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI dialogText, nameText;
    [SerializeField] GameObject dialogBox, nameBox;

    [SerializeField] string[] dialogSentences;
    [SerializeField] int currentSentence;
    [SerializeField] GameObject GamePlayUI;
    [SerializeField] Animator cameraCtrl;
    [SerializeField] Image NPCImage;

    public static DialogController instance;

    private bool dialogJustStarted;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        dialogText.text = dialogSentences[currentSentence];
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonUp("Fire1"))
        {
            if(!dialogJustStarted)
            {
                currentSentence++;

                if(currentSentence >= dialogSentences.Length)
                {
                    dialogBox.SetActive(false);
                    GameManager.instance.dialogBoxOpened = false;
                    GamePlayUI.SetActive(true);
                    if(cameraCtrl != null){
                    cameraCtrl.Play("zoomOut");
                    }
                }
                else
                {
                    CheckForName();
                    dialogText.text = dialogSentences[currentSentence];
                }
            }
            else
            {
                dialogJustStarted = false;
            }

        }
    }
    public void ActivateDialog(string[] newSentencesToUse)
    {
        dialogSentences = newSentencesToUse;
        currentSentence = 0;

        CheckForName();
        dialogText.text = dialogSentences[currentSentence];
        dialogBox.SetActive(true);

        dialogJustStarted = true;
        GameManager.instance.dialogBoxOpened = true;
        GamePlayUI.SetActive(false);
        if(cameraCtrl != null){
        cameraCtrl.Play("zoom");}
    }

    public void SetImage(Sprite NPC)
    {
        NPCImage.sprite = NPC;
    }

    void CheckForName()
    {
        if(dialogSentences[currentSentence].StartsWith("#"))
        {
            nameText.text = dialogSentences[currentSentence].Replace("#", "");
            currentSentence++;
        }
    }

    public bool IsDialogBoxActive()
    {
        return dialogBox.activeInHierarchy;
    }
}
