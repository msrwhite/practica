using System.Buffers.Text;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreenController : MonoBehaviour
{

    void Update()
    {
 
        if (Input.anyKeyDown)
        {
       
            SceneManager.LoadScene("Game");
        }
    }
    
   
}