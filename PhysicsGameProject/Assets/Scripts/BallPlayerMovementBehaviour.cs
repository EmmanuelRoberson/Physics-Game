using System;
using UnityEngine;

public class BallPlayerMovementBehaviour : MonoBehaviour, IPlayerControllable
{
    [SerializeReference] private Transform _headTransform;

    public float moveSpeed;
    
    private Transform _selfTransform;
    
    private PlayerControls _controls;
    private Vector3 _moveVector;
    private Vector3 _lookVector;

    public void Awake()
    {
        _selfTransform = transform;
        PlayerControlsMovementBehaviour.AddPlayerMovement(this);
    }

    public void Move(params Vector3[] vector3s)
    {
        Vector3 inputVector = vector3s[0];
        
        _moveVector =
            _selfTransform.forward * inputVector.y +
            _selfTransform.right * inputVector.x;
    }

    public void Rotate(params Vector3[] vector3s)
    {
        Vector3 mouseDeltaVector = vector3s[0];

        _lookVector =
            mouseDeltaVector;
    }

    public void CancelMove(params Vector3[] vector3s)
    {
        Vector3 inputVector = vector3s[0];
        
        _moveVector =
            _selfTransform.forward * inputVector.y +
            _selfTransform.right * inputVector.x;
    }

    public void FixedUpdate()
    {
        _selfTransform.position += moveSpeed * Time.fixedDeltaTime * _moveVector;

        Vector3 newEulerAngles = _headTransform.eulerAngles;
        newEulerAngles += new Vector3(-_lookVector.y, 0, 0);
        
        _headTransform.eulerAngles = newEulerAngles;
        _selfTransform.localEulerAngles += new Vector3(0,_lookVector.x,0);
        
    }
}
