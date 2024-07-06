using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticObject : MonoBehaviour
{
    
    public GameObject controller;

    public int matrixX;
    public int matrixY;

    

    public void SetCoords(int x, int y)
    {
        matrixX = x;
        matrixY = y;
    }

    
}
