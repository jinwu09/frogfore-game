using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuUIManager : MonoBehaviour
{
    private PlayerStats[] playerStats;
    [SerializeField] TextMeshProUGUI nameText, playerGold;
    [SerializeField] Slider xpSlider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerStats = GameManager.instance.GetPlayerStats();
        nameText.text = playerStats[0].playerName;
        playerGold.text = playerStats[0].playerGold.ToString();
        xpSlider.maxValue = playerStats[0].xpForNextLevel[playerStats[0].playerLevel];
        xpSlider.value = playerStats[0].currentXp;
    }
}
