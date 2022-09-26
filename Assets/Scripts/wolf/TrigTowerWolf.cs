using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation.Examples;

public class TrigTowerWolf : MonoBehaviour
{
    GameObject target;
    List<GameObject> enemiesInZone = new List<GameObject>();
    float dist;
    int i;

    private void FixedUpdate()
    {
        for (i = 0; i < enemiesInZone.Count; i++)
        {
            if (!enemiesInZone[i]) 
            {
                enemiesInZone.Remove(enemiesInZone[i]); i--;
            }
        }
        dist = 0;
        foreach (GameObject enemy in enemiesInZone)
        {
            if (enemy.GetComponent<PathFollower>().distanceTravelled > dist)
            {
                dist = enemy.GetComponent<PathFollower>().distanceTravelled;
                GetComponent<TowerWolf>().target = enemy.transform;
                target = enemy;
            }
        }
        if (enemiesInZone.Count == 0) GetComponent<TowerWolf>().target = null;
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
