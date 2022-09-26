using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Place : MonoBehaviour
{
    List<GameObject> placesList = new List<GameObject>();
    int i;
    public GameObject place;
    public GameObject wolfPref;
    public GameObject rabbitPref;
    public GameObject bearPref;
    GameObject tower;
    bool empty = true;
    string towerType = "null";


    void Start()
    {
        placesList = GameObject.FindGameObjectsWithTag("Place").ToList();
        for (i = 0; i < placesList.Count; i++) if (placesList[i].name == name) place = placesList[i];
    }

    public void UpdateInfo()
    {
        
    }

    public void BuyWolf()
    {
        if (empty && Money.money >= 3)
        {
            tower = GameObject.Instantiate(wolfPref, place.transform.position, Quaternion.identity) as GameObject;
            Money.money -= 3;
            towerType = "wolf";
            empty = false;
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(true);
        }
    }
    public void BuyRabbit()
    {
        if (empty && Money.money >= 4)
        {
            tower = GameObject.Instantiate(rabbitPref, place.transform.position, Quaternion.identity) as GameObject;
            Money.money -= 4;
            towerType = "rabbit";
            empty = false;
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(true);
        }
    }
    public void BuyBear()
    {
        if (empty && Money.money >= 5)
        {
            tower = GameObject.Instantiate(bearPref, place.transform.position, Quaternion.identity) as GameObject;
            Money.money -= 5;
            towerType = "bear";
            empty = false;
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(3).gameObject.SetActive(true);
        }
    }
    public void Sell()
    {
        if (!empty)
        {
            Money.money ++;
            Destroy(tower);
            towerType = "null";
            empty = true;
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(false);
            transform.GetChild(3).gameObject.SetActive(false);
        }
    }
}
