using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCQuest : MonoBehaviour
{
    // Array to hold all NPC game objects
    public GameObject[] npcs;

    // Update is called once per frame
    void Start()
    {
        
    }
    void Update()
    {
        // Check if the player has talked to all NPCs
        if (CheckAllNPCsTalked())
        {
            Debug.Log("You have talked to all NPCs!");
            TaskManager taskManager = GameObject.FindObjectOfType<TaskManager>();
            Task task = taskManager.GetTask("Ms. Extrovert");
            if (task != null)
            {
                task.MarkAsComplete();
            }
        }
    }

    // Method to check if the player has talked to all NPCs
    bool CheckAllNPCsTalked()
    {
        foreach (GameObject npc in npcs)
        {
            // Assuming each NPC has an NPCScript attached
            NPCScript npcScript = npc.GetComponent<NPCScript>();

            if (npcScript != null && !npcScript.HasTalkedToPlayer())
            {
                // If any NPC has not been talked to, return false
                return false;
            }
        }

        // If all NPCs have been talked to, return true
        return true;
    }
}
