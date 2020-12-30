
using System.Collections.Generic;
using UnityEngine;

public abstract class WorkerBase
{
    protected Queue<TaskBase> _taskQueue;
    protected Queue<TaskBase> _priorityTaskQueue;
    public abstract bool ExecuteTask(TaskBase task);
    public abstract void NavigateToNextTask();
    public abstract bool QueueTask(TaskBase task);
}
