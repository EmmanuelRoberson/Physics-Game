using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
public class NavMeshAgentBehaviour : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent _navMeshAgent;
    private Queue<Transform> _destinationQueue;
    
    // Start is called before the first frame update
    void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _destinationQueue = new Queue<Transform>();
    }

    //Enqueue more Transforms to _destinationQueue
    public void AddDestinationsToQueue(params Transform[] destinations)
    {
        for (int i = 0; i < destinations.Length; i++)
        {
            _destinationQueue.Enqueue(destinations[i]);
        }
    }

    public void QueNextDestination()
    {
        _navMeshAgent.SetDestination(_destinationQueue.Dequeue().position);
    } 
}
