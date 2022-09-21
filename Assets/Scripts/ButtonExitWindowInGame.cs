using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonExitWindowInGame : MonoBehaviour
{
    public GameObject exitWindow;
    // Start is called before the first frame update
    public void ExitToMainMenu()
    {
        SceneManager.LoadScene ("SceneMainMenu");
        Time.timeScale = 1f;
    }

    public void BackToGame()
    {
        exitWindow.SetActive(false);
    }

    public void ToMainMenu()
    {
        exitWindow.SetActive(true);
    }
}
