using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CookingMenuManager : MonoBehaviour
{
    [SerializeField] GameObject EnterButton;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            EnterButton.SetActive(true);
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            EnterButton.SetActive(false);
        }
    }
    public void LoadCooking(string SceneToLoad) 
    {
        SceneManager.LoadScene(SceneToLoad);
    }
}
