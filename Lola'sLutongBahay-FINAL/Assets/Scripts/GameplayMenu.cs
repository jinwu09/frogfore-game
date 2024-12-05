using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameplayMenu : MonoBehaviour
{
    public static GameplayMenu instance;
    [SerializeField] TextMeshProUGUI currentBitCoinText;
    [SerializeField] Slider[] xpSlider;

    private PlayerStats[] playerStats;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentBitCoinText != null)
        {
            currentBitCoinText.text = "₱ " + GameManager.instance.currentBitcoins;
        }
        if(xpSlider != null)
        {
            playerStats = GameManager.instance.GetPlayerStats();

            xpSlider[0].maxValue = playerStats[0].xpForNextLevel[playerStats[0].playerLevel];
            xpSlider[0].value = playerStats[0].currentXp;
        }
    }
}
