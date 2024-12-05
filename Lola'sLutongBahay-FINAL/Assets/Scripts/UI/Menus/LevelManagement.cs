using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelManagement : MonoBehaviour
{

    [SerializeField] Image LevelPanel;
    [SerializeField] TextMeshProUGUI LevelName;
    [SerializeField] string LevelNameTexts;
    [SerializeField] Image DishImage;
    [SerializeField] Image Button;
    [SerializeField] Button EnterButton;
    [SerializeField] TextMeshProUGUI BtnImage;
    [SerializeField] GameObject Lock;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UnlockLevel()
    {
        LevelPanel.color = Color.white;
        LevelName.text = LevelNameTexts;
        DishImage.color = Color.white;
        Button.color = Color.white;
        EnterButton.interactable = true;
        BtnImage.text = "ENTER";
        Lock.SetActive(false);
    }
}
