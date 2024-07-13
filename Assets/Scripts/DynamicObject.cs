using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DynamicObject : MonoBehaviour
{


    public GameObject controller;
    public GameObject movePlate;


    protected int xBoard = -1;
    protected int yBoard = -1;

    protected string player;


    public Sprite red_object;
    public Sprite blue_object;

    protected int objweight;

    public void Activate()
    {

        controller = GameObject.FindGameObjectWithTag("GameController");

        SetCoords();

        switch (this.name)
        {

            case "red_object": this.GetComponent<SpriteRenderer>().sprite = red_object; player = "red"; break;

            case "blue_object": this.GetComponent<SpriteRenderer>().sprite = blue_object; player = "blue"; break;

        }
    }

    public void SetCoords()
    {
   
        float x = xBoard;
        float y = yBoard;

        x *= 5.5f;
        y *= 5.5f;

        x += -10.87f;
        y += -19.25f;

        this.transform.position = new Vector3(x, y, -1.0f);
    }

    public int GetXBoard()
    {
        return xBoard;
    }

    public int GetYBoard()
    {
        return yBoard;
    }

    public void SetXBoard(int x)
    {
        xBoard = x;
    }

    public void SetYBoard(int y)
    {
        yBoard = y;
    }

    private void OnMouseUp()
    {
        if (!controller.GetComponent<Game>().IsGameOver() && controller.GetComponent<Game>().GetCurrentPlayer() == player)
        {
            
            DestroyMovePlates();

            
            InitiateMovePlates();
          

        }
    }

    public void DestroyMovePlates()
    {
        
        GameObject[] movePlates = GameObject.FindGameObjectsWithTag("MovePlate");
        for (int i = 0; i < movePlates.Length; i++)
        {
            Destroy(movePlates[i]); 
        }
    }

    public abstract void InitiateMovePlates();
    




    public void PointMovePlate(int x, int y)
    {
        Game sc = controller.GetComponent<Game>();
        if (sc.PositionOnBoard(x, y))
        {
            GameObject cp = sc.GetPosition(x, y);

            if (cp == null)
            {
                MovePlateSpawn(x, y);
            }
            else if (cp.GetComponent<DynamicObject>().player != player)
            {
                MovePlateAttackSpawn(x, y);
            }
        }
    }



    public void MovePlateSpawn(int matrixX, int matrixY)
    {
    
        float x = matrixX;
        float y = matrixY;


        x *= 5.5f;
        y *= 5.5f;

        x += -10.87f;
        y += -19.25f;

        GameObject mp = Instantiate(movePlate, new Vector3(x, y, -3.0f), Quaternion.identity);

        MovePlate mpScript = mp.GetComponent<MovePlate>();
        mpScript.SetReference(gameObject);
        mpScript.SetCoords(matrixX, matrixY);
    }

    public void MovePlateAttackSpawn(int matrixX, int matrixY)
    {
        
        float x = matrixX;
        float y = matrixY;

        
        x *= 5.5f;
        y *= 5.5f;

        
        x += -10.87f;
        y += -19.25f;

        
        GameObject mp = Instantiate(movePlate, new Vector3(x, y, -3.0f), Quaternion.identity);

        MovePlate mpScript = mp.GetComponent<MovePlate>();
        mpScript.attack = true;
        mpScript.SetReference(gameObject);
        mpScript.SetCoords(matrixX, matrixY);
    }

    public int ObjWeight
    {
        get { return objweight; }
        set { objweight = value; }
    }
}
