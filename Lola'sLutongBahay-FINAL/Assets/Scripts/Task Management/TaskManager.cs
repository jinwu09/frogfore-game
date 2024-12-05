using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TaskManager : MonoBehaviour
{
    public static TaskManager instance;
    public List<Task> tasks = new List<Task>();
    [SerializeField] UnityEvent allTaskFinished;
    private bool EndGame = true;

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
        
    }

    void Update()
    {
        if(AreAllTasksComplete() && EndGame)
        {
            allTaskFinished.Invoke();
            EndGame = false;
        }
    }

    public void AddTask(string title)
    {
        Task newTask = new Task(title);
        tasks.Add(newTask);
    }

    public Task GetTask(string title)
    {
        return tasks.Find(task => task.title == title);
    }

    public void MarkTaskAsComplete(string title)
    {
        Task task = GetTask(title);
        if (task != null)
        {
            task.MarkAsComplete();
        }
    }
    public bool IsTaskComplete(string title)
    {
        Task task = GetTask(title);
        return task != null && task.taskComplete;
    }

    public bool AreAllTasksComplete()
{
    if (tasks.Count == 0)
    {
        return true;
    }

    foreach (Task task in tasks)
    {
        if (!task.taskComplete)
        {
            return false; // If any task is incomplete, return false
        }
    }

    return true; // All tasks are complete
}
}
