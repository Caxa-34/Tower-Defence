using UnityEngine;
using UnityEngine.UI;

public class ButtonPauseResume : MonoBehaviour
{
    bool isPause = false;
    public GameObject dark;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) Click();    
    }

    public void Click()
    {
        if (isPause) Resume();
        else Pause();
    }

    public void Resume()
    {
        GetComponent<Image>().sprite = Resources.Load<Sprite>("pause");
            Time.timeScale = 1f;
            dark.SetActive(false);
            isPause = false;
    }
    public void Pause()
    {
            GetComponent<Image>().sprite = Resources.Load<Sprite>("resume");
            Time.timeScale = 0f;
            dark.SetActive(true);
            isPause = true;
    }
}
