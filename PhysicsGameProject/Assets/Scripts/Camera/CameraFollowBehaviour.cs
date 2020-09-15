using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowBehaviour : MonoBehaviour
{
    private Transform _selfTransform;
    
    [SerializeField]
    private Transform objectOfFocus;

    public int distance;
    
    // Start is called before the first frame update
    void Start()
    {
        _selfTransform = transform;
    }

    void FixedUpdate()
    {
        
    }
}
