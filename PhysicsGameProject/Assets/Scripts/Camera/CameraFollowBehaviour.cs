using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class CameraFollowBehaviour : MonoBehaviour
{
    private Transform _selfTransform;
    private Vector3 _focusOffset;
    
    [SerializeField]
    private Transform objectOfFocus;

    public float followSpeed = 15;
    public float yOffset;
    public float zOffset;
    public bool smoothFollow;



    public float smoothTime;

    public Vector3 velocity = Vector3.zero;
    
    // Start is called before the first frame update
    void Start()
    {
        _selfTransform = transform;

        yOffset = 10;
        zOffset = -5;
    }

    void FixedUpdate()
    {
        /*
        if (objectOfFocus)
        {
            Vector3 newPosition = _selfTransform.position;
            newPosition.x = objectOfFocus.position.x;
            newPosition.z = objectOfFocus.position.z + zOffset;
            newPosition.y = objectOfFocus.position.y + yOffset;

            if (!smoothFollow) transform.position = newPosition;
            else transform.position = Vector3.Lerp(_selfTransform.position, newPosition, followSpeed * Time.deltaTime);
        }
        */
        
    }

    private void LateUpdate()
    {
        SmoothFollow();
    }

    void SmoothFollow()
    {
        Vector3 targetPosition = objectOfFocus.position;
        targetPosition.x = objectOfFocus.position.x;
        targetPosition.z = objectOfFocus.position.z + zOffset;
        targetPosition.y = objectOfFocus.position.y + yOffset;
        
        Vector3 currentPosition = Vector3.SmoothDamp(_selfTransform.position, targetPosition, ref velocity, smoothTime);

        _selfTransform.position = currentPosition;
    }
    
}
