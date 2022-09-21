using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawn : MonoBehaviour
{
    public int numberWave = 0;

    int[,] countEnemies = new int[15, 4]
    { {3, 0, 0, 0}, 
    {5, 0, 0, 0},
    {8, 0, 0, 0},
    {10, 1, 0, 0},
    {12, 1, 0, 0},
    {14, 2, 0, 0},
    {15, 4, 0, 0},
    {16, 5, 0, 0},
    {17, 5, 1, 0},
    {18, 6, 2, 0},
    {19, 6, 2, 0},
    {20, 6, 2, 0}, 
    {21, 6, 3, 0},
    {23, 6, 4, 1},
    {25, 6, 4, 3}
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
    public GameObject spawnPoint;

    public float intervalSpawn = 1;
    
    void Start()
    {
        countlog1 = countEnemies[numberWave, 0];
        countlog2 = countEnemies[numberWave, 1];
        countlog3 = countEnemies[numberWave, 2];
        countlog4boss = countEnemies[numberWave, 3];
        countOnMap = countlog1 + countlog2 + countlog3 + countlog4boss;
        
        Debug.Log(countlog1.ToString());
        intervalSpawn = 1f - 0.03f * numberWave;
        InvokeRepeating("SpawnEnemy", 2, intervalSpawn);
    }

    // Update is called once per frame
    void Update()
    {
        if ((countlog1 + countlog2 + countlog3 + countlog4boss == 0) && (numberWave < 15) && (countOnMap == 0))
        {
            CancelInvoke("SpawnEnemy");
            numberWave++;
            Start();
        }
    }

    void SpawnEnemy()
    {
        if(countlog1 > 0)
        {
        GameObject log1 = GameObject.Instantiate(log1Pref, spawnPoint.transform.position, Quaternion.identity) as GameObject;

        countlog1--;
        }
        if(countlog2 > 0)
        {
        GameObject log2 = GameObject.Instantiate(log2Pref, spawnPoint.transform.position, Quaternion.identity) as GameObject;
        countlog2--;
        }
        if(countlog3 > 0)
        {
        GameObject log3 = GameObject.Instantiate(log3Pref, spawnPoint.transform.position, Quaternion.identity) as GameObject;
        countlog3--;
        }
        if(countlog4boss > 0)
        {
        GameObject log4boss = GameObject.Instantiate(log4bossPref, spawnPoint.transform.position, Quaternion.identity) as GameObject;
        countlog4boss--;
        }
    }
}
