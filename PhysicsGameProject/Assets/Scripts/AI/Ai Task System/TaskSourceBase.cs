
public abstract class TaskSourceBase
{
    protected abstract TaskBase GenerateTask();
    public abstract bool CompleteTask(TaskBase task);
}
