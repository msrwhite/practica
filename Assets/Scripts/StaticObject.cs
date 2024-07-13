using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StaticObject : MonoBehaviour
{
    
    public GameObject controller;
    public GameObject reference = null;
    public int matrixX;
    public int matrixY;

    

    public void SetCoords(int x, int y)
    {
        matrixX = x;
        matrixY = y;
    }

    public void SetReference(GameObject obj)
    {
        reference = obj;
    }

    public GameObject GetReference()
    {
        return reference;
    }
}
