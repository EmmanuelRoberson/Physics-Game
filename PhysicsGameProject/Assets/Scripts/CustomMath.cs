using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CustomMath
{
    private static float floatComparisonTolerance = 0.001f;
    
    /// <summary>
    /// "Directionalize Vector will take the direction of each value of the directional vector, and apply each one to the original vector
    /// </summary>
    /// <param name="originalVector"></param>
    /// <param name="directionalVector"></param>
    /// <returns></returns>
    public static Vector3 DirectionalizeVector(Vector3 originalVector, Vector3 directionalVector)
    {
        float xValue = (Math.Abs(directionalVector.x) > floatComparisonTolerance) ? directionalVector.x * originalVector.x : originalVector.x;
        float yValue = (Math.Abs(directionalVector.x) > floatComparisonTolerance) ? directionalVector.y * originalVector.y : originalVector.y;
        float zValue = (Math.Abs(directionalVector.x) > floatComparisonTolerance) ? directionalVector.z * originalVector.z : originalVector.z;
        
        return new Vector3(xValue, yValue, zValue);
    }

    public static Vector3 DirectionalizeVector(Vector3 originalVector, Vector2 directionalVector)
    {
        float xValue = (Math.Abs(directionalVector.x) > floatComparisonTolerance) ? directionalVector.x * originalVector.x : originalVector.x;
        float yValue = (Math.Abs(directionalVector.x) > floatComparisonTolerance) ? directionalVector.y * originalVector.y : originalVector.y;
        float zValue = originalVector.z;

        return new Vector3(xValue, yValue, zValue);
    }
    
}
