using UnityEngine;

public class QuestManager : MonoBehaviour
{
    // Reference to the player's inventory
    public Inventory playerInventory;

    // Reference to the task manager
    public TaskManager taskManager;

    // Quest item that you are looking for
    public string questItemName; // Assuming you identify quest items by name

    // Task title associated with this quest
    public string questTaskTitle; // Adjust this based on your task titles

    // Method to check if the quest item is in the inventory
    public void CheckQuestItem()
    {
        if (playerInventory.HasQuestItem(questItemName))
        {
            // Quest item found in the inventory
            Debug.Log("Quest item found! Marking task as complete...");
            
            // Mark the associated task as complete
            taskManager.MarkTaskAsComplete(questTaskTitle);

            // Add your additional quest completion logic here
        }
        else
        {
            // Quest item not found in the inventory
            Debug.Log("Quest item not found...");
            // Add your logic for when the quest item is not found
        }
    }
}
