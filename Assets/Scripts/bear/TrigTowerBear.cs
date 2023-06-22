using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation.Examples;

public class TrigTowerBear : MonoBehaviour
{
    public TowerBear tower;
    List<GameObject> enemiesInZone = new List<GameObject>();
    private void FixedUpdate()
    {
        for (int i = 0; i < enemiesInZone.Count; i++)
        {
            if (!enemiesInZone[i]) 
            {
                enemiesInZone.Remove(enemiesInZone[i]); i--;
            }
        }
        
        if (enemiesInZone.Count == 0) tower.target = null;
        SortByDist();
        if (enemiesInZone.Count > 0) tower.target = enemiesInZone[0].transform;
        foreach (GameObject enemy in enemiesInZone)
        {
            if (!enemy.GetComponent<hpEnemy>().isResist)
            {
                tower.target = enemy.transform;
                break;
            }
        }
        if (enemiesInZone.Count == 0) tower.target = null;
    }

    void SortByDist()   {
        for (int i = 0; i < enemiesInZone.Count; i++)
            for (int j = i + 1; j < enemiesInZone.Count; j++) {
                if (enemiesInZone[i].GetComponent<PathFollower>().distanceTravelled < enemiesInZone[j].GetComponent<PathFollower>().distanceTravelled){
                    GameObject c = enemiesInZone[i];
                    enemiesInZone[i] = enemiesInZone[j];
                    enemiesInZone[j] = c;
                }
            }
    }

    void OnTriggerEnter(Collider other)
    {
        enemiesInZone.Add(other.gameObject);
    }

    void OnTriggerExit(Collider other)
    {
        enemiesInZone.Remove(other.gameObject);
    }
}
