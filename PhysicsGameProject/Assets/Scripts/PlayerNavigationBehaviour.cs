using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerNavigationBehaviour : MonoBehaviour
{
    private NavMeshAgent _selfNavMeshAgent;

    [SerializeField] private Transform targetTransform;
    // Start is called before the first frame update
    void Start()
    {
        _selfNavMeshAgent = GetComponent<NavMeshAgent>();
        _selfNavMeshAgent.SetDestination(targetTransform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
}
