using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonReload : MonoBehaviour
{
    public GameObject reloadWindow;
    // Start is called before the first frame update

    public void ReloadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void BaсkToGame()
    {
        reloadWindow.SetActive(false);
    }

    public void ToReload()
    {
        reloadWindow.SetActive(true);
    }
}
