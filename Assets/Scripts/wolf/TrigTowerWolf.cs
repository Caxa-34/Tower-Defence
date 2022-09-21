using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation.Examples;

public class TrigTowerWolf : MonoBehaviour
{
    public TowerWolf tower;
    GameObject target;
    List<GameObject> enemiesInZone = new List<GameObject>();
    float dist;

    private void FixedUpdate()
    {
        if (!target) enemiesInZone.Remove(target);

        dist = 0;
        foreach (GameObject enemy in enemiesInZone)
        {
            if (enemy.GetComponent<PathFollower>().distanceTravelled > dist)
            {
                dist = enemy.GetComponent<PathFollower>().distanceTravelled;
                tower.target = enemy.transform;
                target = enemy;
            }
        }
        if (enemiesInZone.Count == 0) tower.target = null;
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
