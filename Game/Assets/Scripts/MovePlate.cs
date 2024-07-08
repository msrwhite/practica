using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlate : StaticObject
{
    public GameObject reference = null;
   
    public bool attack = false;

    public void Start()
    {
        if (attack)
        {
         
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
        }
    }

    public void OnMouseUp()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");
        if (matrixX == 2 && matrixY == 0 && reference.name != "blue_object")
        {
            Destroy(reference);
            controller.GetComponent<Game>().Winner("Red");
        }
        if (matrixX == 2 && matrixY == 7 && reference.name != "red_object")
        {
            Destroy(reference);
            controller.GetComponent<Game>().Winner("Blue");
        }
        
        if (attack)
        {
            GameObject cp = controller.GetComponent<Game>().GetPosition(matrixX, matrixY);
            DynamicObject referenceDynamic = reference.GetComponent<DynamicObject>();
            DynamicObject cpDynamic = cp.GetComponent<DynamicObject>();

            if (referenceDynamic.ObjWeight == 1 && cpDynamic.ObjWeight == 2)
            {
               
                cpDynamic.ObjWeight = 1;

               
                Destroy(reference);
            }
            else if (referenceDynamic.ObjWeight >= cpDynamic.ObjWeight)
            {
            
                Destroy(cp);
                controller.GetComponent<Game>().SetPositionEmpty(referenceDynamic.GetXBoard(), referenceDynamic.GetYBoard());

                
                referenceDynamic.SetXBoard(matrixX);
                referenceDynamic.SetYBoard(matrixY);
                referenceDynamic.SetCoords();

         
                controller.GetComponent<Game>().SetPosition(reference);
            }
            else
            {
               
                Destroy(reference);
            }

            Debug.Log("ObjWeight атакующего объекта: " + referenceDynamic.ObjWeight);
            Debug.Log("ObjWeight атакуемого объекта: " + cpDynamic.ObjWeight);
        }


       
        controller.GetComponent<Game>().SetPositionEmpty(reference.GetComponent<DynamicObject>().GetXBoard(), 
            reference.GetComponent<DynamicObject>().GetYBoard());

       
        reference.GetComponent<DynamicObject>().SetXBoard(matrixX);
        reference.GetComponent<DynamicObject>().SetYBoard(matrixY);
        reference.GetComponent<DynamicObject>().SetCoords();

   
        controller.GetComponent<Game>().SetPosition(reference);

    
        controller.GetComponent<Game>().NextTurn();

      
        reference.GetComponent<DynamicObject>().DestroyMovePlates();
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
