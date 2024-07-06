using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
   
    public GameObject chesspiece;
    public GameObject obj1;
    public GameObject obj2;
    public GameObject base1;
    public GameObject base2;
   
    private GameObject[,] positions = new GameObject[5, 8];
    private GameObject[] playerRed = new GameObject[10];
    private GameObject[] playerBlue = new GameObject[10];

   
    private string currentPlayer = "blue";

    
    private bool gameOver = false;

    public void Start()
    {
        playerBlue = new GameObject[] { Create(obj1, "blue_object", 1, 0) , Create(obj1, "blue_object", 3, 0), Create(obj1, "blue_object", 0, 0), 
            Create(obj1, "blue_object", 4, 0), Create(obj2, "blue_object", 2, 1) };
        playerRed = new GameObject[] { Create(obj1, "red_object", 1, 7) , Create(obj1, "red_object", 3, 7), Create(obj1, "red_object", 0, 7),
            Create(obj1, "red_object", 4, 7), Create(obj2, "red_object", 2, 6) };
      
       
        for (int i = 0; i < playerRed.Length; i++)
        {
            SetPosition(playerRed[i]);
            SetPosition(playerBlue[i]);
        }
        base1 = CreateBase(base1, 2, 0);
        base2 = CreateBase(base2, 2, 7);


    }
    public GameObject CreateBase(GameObject obj1, int x1, int y1)
    { 
        
        float x = x1;
        float y = y1;

       
        x *= 5.5f;
        y *= 5.5f;

        
        x += -10.87f;
        y += -19.25f;

        GameObject obj = Instantiate(obj1, new Vector3(x, y, -1), Quaternion.identity);
       
        Base baseComponent = obj.GetComponent<Base>();
        baseComponent.SetCoords(x1, y1);
        baseComponent.SetBaseSprite(true); 
        
       
        return obj;

       
    }
    public GameObject Create(GameObject obj1, string name, int x, int y)
    {
        GameObject obj = Instantiate(obj1, new Vector3(0, 0, -1), Quaternion.identity);
        DynamicObject cm = obj.GetComponent<DynamicObject>(); 
        cm.name = name; 
        cm.SetXBoard(x);
        cm.SetYBoard(y);
        cm.Activate(); 
        return obj;
    }

    public void SetPosition(GameObject obj)
    {
        DynamicObject cm = obj.GetComponent<DynamicObject>();

        
        positions[cm.GetXBoard(), cm.GetYBoard()] = obj;
    }

    public void SetPositionEmpty(int x, int y)
    {
        positions[x, y] = null;
    }

    public GameObject GetPosition(int x, int y)
    {
        return positions[x, y];
    }

    public bool PositionOnBoard(int x, int y)
    {
        if (x < 0 || y < 0 || x >= positions.GetLength(0) || y >= positions.GetLength(1)) return false;
        return true;
    }

    public string GetCurrentPlayer()
    {
        return currentPlayer;
    }

    public bool IsGameOver()
    {
        return gameOver;
    }

    public void NextTurn()
    {
        if (currentPlayer == "blue")
        {
            currentPlayer = "red";
        }
        else
        {
            currentPlayer = "blue";
        }
    }

    public void Update()
    {
        if (gameOver == true && Input.GetMouseButtonDown(0))
        {
            gameOver = false;

            
            SceneManager.LoadScene("Game"); 
        }
    }
    
    public void Winner(string playerWinner)
    {
        gameOver = true;

        if (playerWinner == "Red")
        {
            Base baseComponent = base1.GetComponent<Base>();
            baseComponent.SetBaseSprite(false);
          
        } else
        {
            Base baseComponent = base2.GetComponent<Base>();
            baseComponent.SetBaseSprite(false);
        }
            
        
        
        GameObject.FindGameObjectWithTag("WinnerText").GetComponent<Text>().enabled = true;
        GameObject.FindGameObjectWithTag("WinnerText").GetComponent<Text>().text = playerWinner + " wins!";

        GameObject.FindGameObjectWithTag("RestartText").GetComponent<Text>().enabled = true;
    }
}
