using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonReload : MonoBehaviour
{
    public GameObject reloadWindow;

    public void ReloadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
        Money.money = 5;
        WaveSpawn.score = 0;
        WaveSpawn.countOnMap = 0;
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
