using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class QuestItem : MonoBehaviour
{

    [SerializeField] string taskName;
    [SerializeField] UnityEvent onPickup;
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
            CompleteTask();
            onPickup.Invoke();
        }
    }

    public void CompleteTask()
    {
        TaskManager taskManager = GameObject.FindObjectOfType<TaskManager>();
        Task task = taskManager.GetTask(taskName);
        if (task != null)
        {
            task.MarkAsComplete();
            onPickup.Invoke();
        }
    }
}
