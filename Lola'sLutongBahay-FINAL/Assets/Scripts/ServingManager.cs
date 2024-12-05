using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ServingManager : MonoBehaviour
{
    public List<string> recipe = new List<string>(); // List of required actions in the recipe
    public List<string> playerActions = new List<string>(); // List to store the player's actions
    // Start is called before the first frame update

    [SerializeField] UnityEvent ActionEvent;
    void Start()
    {
        
    }

    public string CheckSequence()
    {
        if (playerActions.Count == recipe.Count)
        {
            ActionEvent.Invoke();
            return "Congrats Complete!";
        }
        else
        {
            return "Still More!";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
