using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRaycastBehaviour : MonoBehaviour
{
    private Camera _selfCamera;

    private RaycastHit _raycastHit;
    private Ray _ray;
    
    // Start is called before the first frame update
    void Start()
    {
        _selfCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        _ray = _selfCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(_ray, out _raycastHit))
        {
            Vector3 positionHit = _raycastHit.transform.position;
        }
    }
}
