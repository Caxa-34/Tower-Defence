using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class hpBase : MonoBehaviour
{
    public int hp = 5;
    public GameObject loseWindow;
    public GameObject hps;

    void Update()
    {
        if (hp <= 0)
        {
            int[] records = new int[6] {0, 0, 0, 0, 0, 0}; int i = 0, j = 0;
            if (PlayerPrefs.HasKey("rec1")) records[0] = PlayerPrefs.GetInt("rec1");
            if (PlayerPrefs.HasKey("rec2")) records[1] = PlayerPrefs.GetInt("rec2");
            if (PlayerPrefs.HasKey("rec3")) records[2] = PlayerPrefs.GetInt("rec3");
            if (PlayerPrefs.HasKey("rec4")) records[3] = PlayerPrefs.GetInt("rec4");
            if (PlayerPrefs.HasKey("rec5")) records[4] = PlayerPrefs.GetInt("rec5");
            if (PlayerPrefs.HasKey("rec6")) records[5] = PlayerPrefs.GetInt("rec6");
            int minIndex = 0;
            for (i = 1; i < 6; i++) if (records[i] < records[minIndex]) minIndex = i;
            records[minIndex] = WaveSpawn.score;

            for (i = 0; i < 6; i++)
			    for (j = 0; j < 5; j++)
				    if (records[j] < records[j + 1])
				    {
					    int t = records[j + 1];
					    records[j + 1] = records[j];
					    records[j] = t;
				    }
            PlayerPrefs.SetInt("rec1", records[0]);
            PlayerPrefs.SetInt("rec2", records[1]);
            PlayerPrefs.SetInt("rec3", records[2]);
            PlayerPrefs.SetInt("rec4", records[3]);
            PlayerPrefs.SetInt("rec5", records[4]);
            PlayerPrefs.SetInt("rec6", records[5]);
            PlayerPrefs.Save();

            hp = 10;
            loseWindow.SetActive(true);
            loseWindow.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text += WaveSpawn.score.ToString() + ".";
            Time.timeScale = 0f;
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        hp--;
        other.gameObject.GetComponent<hpEnemy>().hp = -100;
        hps.transform.GetChild(hp).gameObject.SetActive(false);
    }
}
