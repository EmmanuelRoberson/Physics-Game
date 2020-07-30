using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CustomMath
{
    public static Vector3 DirectionalizedVector(Vector3 originalVector, Vector3 directionalVector)
    {
        return new Vector3(
            originalVector.x * directionalVector.x, 
            originalVector.y * directionalVector.y,
            originalVector.z * directionalVector.z);
    }
}
