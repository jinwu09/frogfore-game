using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateQuest : MonoBehaviour
{
    public string taskName;
    [SerializeField] GameObject interactButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if(interactButton != null){
                interactButton.SetActive(true);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if(interactButton != null){
                interactButton.SetActive(false);
            }
        }
    }

    public void CompleteTask()
    {
        TaskManager taskManager = GameObject.FindObjectOfType<TaskManager>();
        Task task = taskManager.GetTask(taskName);
        if (task != null)
        {
            task.MarkAsComplete();
        }
    }
}
