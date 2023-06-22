using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WaveSpawn : MonoBehaviour
{
    public int numberWave = 0;
    int i, j;
    int[,] countEnemies = new int[15, 4]
    { {3, 0, 0, 0}, 
    {6, 0, 0, 0},
    {10, 0, 0, 0},
    {14, 1, 0, 0},
    {18, 1, 0, 0},
    {20, 2, 0, 0},
    {22, 4, 0, 0},
    {25, 5, 1, 0},
    {28, 5, 1, 0},
    {30, 6, 2, 0},
    {32, 6, 3, 0},
    {35, 6, 3, 0}, 
    {40, 8, 4, 0},
    {45, 8, 5, 1},
    {50, 10, 6, 3}
    };

    public GameObject log1Pref;
    int countlog1;
    public GameObject log2Pref;
    int countlog2;
    public GameObject log3Pref;
    int countlog3;
    public GameObject log4bossPref;
    int countlog4boss;
    static public int countOnMap;
    static public int score = 0;
    public GameObject winWindow;
    public GameObject spawnPoint;
    public GameObject waves;

    public float intervalSpawn = 1f;
    
    void Start()
    {
        countlog1 = countEnemies[numberWave, 0];
        countlog2 = countEnemies[numberWave, 1];
        countlog3 = countEnemies[numberWave, 2];
        countlog4boss = countEnemies[numberWave, 3];
        countOnMap = countlog1 + countlog2 + countlog3 + countlog4boss;
        
        Debug.Log(countlog1.ToString());
        intervalSpawn = 1f - 0.03f * numberWave;
        GetComponent<Money>().maxSpeedMoney = 10f - (0.6f * numberWave);
        StartCoroutine(SpawnEnemy());
        waves.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = "Волна " + (numberWave+1).ToString() + "/15";
        waves.transform.GetChild(0).gameObject.GetComponent<Image>().fillAmount = (numberWave+1)/15f;
    }

    void Update()
    {
        if ((countlog1 + countlog2 + countlog3 + countlog4boss == 0) && (numberWave < 15) && (countOnMap == 0))
        {
            CancelInvoke("SpawnEnemy");
            numberWave++;
            if (numberWave == 5)
            {
                log1Pref.GetComponent<hpEnemy>().maxhp *= 1.5f;
                log2Pref.GetComponent<hpEnemy>().maxhp *= 1.5f;
                log3Pref.GetComponent<hpEnemy>().maxhp *= 1.5f;
                log4bossPref.GetComponent<hpEnemy>().maxhp *= 1.5f;
            }
            if (numberWave == 10)
            {
                log1Pref.GetComponent<hpEnemy>().maxhp *= 1.5f;
                log2Pref.GetComponent<hpEnemy>().maxhp *= 1.5f;
                log3Pref.GetComponent<hpEnemy>().maxhp *= 1.5f;
                log4bossPref.GetComponent<hpEnemy>().maxhp *= 1.5f;
            } 
            if (numberWave == 15)
            {
                
                Win();
                return;
            }
            Start();
        }
    }

    IEnumerator SpawnEnemy()
    {
        for (j = 0; j < 3; j++)
        {
            for (i = 0; i <= countEnemies[numberWave, 0]/3 && countlog1 > 0; i++)
            {
                GameObject log1 = GameObject.Instantiate(log1Pref, spawnPoint.transform.position, Quaternion.identity) as GameObject;
                countlog1--;
                yield return new WaitForSeconds(intervalSpawn);
            }
            for (i = 0; i <= countEnemies[numberWave, 1]/3 && countlog2 > 0; i++)
            {
                GameObject log2 = GameObject.Instantiate(log2Pref, spawnPoint.transform.position, Quaternion.identity) as GameObject;
                countlog2--;
                yield return new WaitForSeconds(intervalSpawn);
            }
            for (i = 0; i <= countEnemies[numberWave, 2]/3 && countlog3 > 0; i++)
            {
                GameObject log3 = GameObject.Instantiate(log3Pref, spawnPoint.transform.position, Quaternion.identity) as GameObject;
                countlog3--;
                yield return new WaitForSeconds(intervalSpawn);
            }
            for (i = 0; i <= countEnemies[numberWave, 3]/3 && countlog4boss > 0; i++)
            {
                yield return new WaitForSeconds(intervalSpawn*3);
                GameObject log4boss = GameObject.Instantiate(log4bossPref, spawnPoint.transform.position, Quaternion.identity) as GameObject;
                countlog4boss--;
                yield return new WaitForSeconds(intervalSpawn);
            }
        }
    }
    
    void Win()
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
        records[minIndex] = score;

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

        winWindow.SetActive(true);
        winWindow.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text += WaveSpawn.score.ToString() + ".";
        Time.timeScale = 0f;
    }
}
