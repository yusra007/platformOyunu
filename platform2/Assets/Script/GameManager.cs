
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
  
    public static bool isRestart = false;
    

    public void restartGame()
    {
        isRestart = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
       
    }

    public void exitGame()
    {
        Application.Quit();
    }

  
}
