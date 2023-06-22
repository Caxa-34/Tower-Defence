using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void ExitGame()
    {
         SceneManager.LoadScene("SceneExit");
    }

    public void BackGame()
    {
         SceneManager.LoadScene("SceneMainMenu");
    }

    public void QuitGame()
    {
         Application.Quit();
    }

     public void Records()
     {
          SceneManager.LoadScene("SceneRecords");
     }

     public void StartGame()
     {
          SceneManager.LoadScene("SceneForest");
          Time.timeScale = 1f;
     }

}
