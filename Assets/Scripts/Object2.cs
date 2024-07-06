using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object2 : DynamicObject
{
    private void Start()
    {
        ObjWeight = 2;
    }

    public override void InitiateMovePlates()
    {
        PointMovePlate(xBoard, yBoard + 1);
        PointMovePlate(xBoard, yBoard - 1);
        PointMovePlate(xBoard + 1, yBoard);
        PointMovePlate(xBoard - 1, yBoard);


    }
}
 