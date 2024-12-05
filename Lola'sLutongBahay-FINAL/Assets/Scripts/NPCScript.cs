using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCScript : MonoBehaviour
{
    // Boolean variable to track whether the player has talked to this NPC
    private bool hasTalkedToPlayer = false;

    // Method to check if the player has talked to this NPC
    public bool HasTalkedToPlayer()
    {
        return hasTalkedToPlayer;
    }

    // Method to set that the player has talked to this NPC
    public void SetTalkedToPlayer()
    {
        hasTalkedToPlayer = true;
    }
}
