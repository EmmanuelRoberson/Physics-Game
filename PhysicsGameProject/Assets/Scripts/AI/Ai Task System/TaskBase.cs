using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class TaskBase
{
    protected List<Transform> CompletionLocations;
    protected Action Purpose;
    protected TaskSourceBase Source;
    protected abstract object CompleteTask();
}
