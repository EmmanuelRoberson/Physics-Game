using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManagerBehaviour : MonoBehaviour
{
    private static Queue<TaskBase> _unassignedTasks;

    public void RecieveTasks(params TaskBase[] tasks)
    { 
        for (int i = 0; i < tasks.Length; i++)
        {
            _unassignedTasks.Enqueue(tasks[i]);
        }
        
    }

    public static void AssignTask(WorkerBase worker)
    {
        worker.QueueTask(_unassignedTasks.Dequeue());
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
