using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerControllable
{
    void Move(params Vector3[] vector3s);
    void Rotate(params Vector3[] vector3s);
    void CancelMove(params Vector3[] vector3s);
}
