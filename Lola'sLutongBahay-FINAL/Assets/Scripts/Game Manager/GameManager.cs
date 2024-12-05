using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] PlayerStats[] playerStats;

    public bool gameMenuOpened, dialogBoxOpened, shopPanelOpened;

    public int currentBitcoins;

    void Start()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);

        //playerStats = FindObjectOfType<PlayerStats>();
    }

    void Update()
    {
        if(gameMenuOpened || dialogBoxOpened || shopPanelOpened)
        {
            PlayerController.instance.deactivateMovement = true;
        }
        else
        {
            PlayerController.instance.deactivateMovement = false;
        }
    }

    public PlayerStats[] GetPlayerStats()
    {
        return playerStats;
    }

    public void DestroyQuitGame()
    {
        // Add any additional cleanup or effects before destroying the GameObject
        Destroy(gameObject);
    }
}