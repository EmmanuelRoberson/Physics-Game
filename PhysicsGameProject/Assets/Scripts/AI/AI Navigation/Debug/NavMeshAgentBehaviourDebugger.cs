using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavMeshAgentBehaviourDebugger : MonoBehaviour
{
    public Transform[] transformArray;

    private NavMeshAgentBehaviour _navMeshAgentBehaviour;
    // Start is called before the first frame update
    void Start()
    {
        _navMeshAgentBehaviour = GetComponent<NavMeshAgentBehaviour>();
        _navMeshAgentBehaviour.AddDestinationsToQueue(transformArray);
        _navMeshAgentBehaviour.QueNextDestination();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other1)
    {

        TaskSourceBehaviourDebugger taskSource = other1.gameObject.GetComponent<TaskSourceBehaviourDebugger>();

        if (taskSource != null)
        {
            
            _navMeshAgentBehaviour.QueNextDestination();
        }
    }
}
