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
    public GameObject tower;
    bool empty = true;
    string towerType = "null";


    void Start()
    {
        placesList = GameObject.FindGameObjectsWithTag("Place").ToList();
        for (i = 0; i < placesList.Count; i++) if (placesList[i].name == name) place = placesList[i];
        transform.GetChild(0).gameObject.SetActive(true);
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
            SetDefault();
        }
    }
    public void BuyRabbit()
    {
        if (empty && Money.money >= 4)
        {
            tower = GameObject.Instantiate(rabbitPref, place.transform.position + new Vector3(0.2f, 0, 0.15f), Quaternion.identity) as GameObject;
            //tower.transform.position = new Vector3(0.2f, 0, 0.2f);
            tower.transform.rotation = Quaternion.Euler(0, 180, 0);
            Money.money -= 4;
            towerType = "rabbit";
            empty = false;
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(true);
            SetDefault();
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
            SetDefault();
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

    public void SetDefault()
    {

        switch (towerType)
        {
            case "wolf":
                transform.GetChild(1).GetComponent<WolfTower>().lvlDamage = 0;
                transform.GetChild(1).GetComponent<WolfTower>().lvlSpeed = 0;
                transform.GetChild(1).GetComponent<WolfTower>().Start();
            break;
            case "rabbit":
                transform.GetChild(2).GetComponent<RabbitTower>().lvlCount = 0;
                transform.GetChild(2).GetComponent<RabbitTower>().lvlDamage = 0;
                transform.GetChild(2).GetComponent<RabbitTower>().Start();
            break;
            case "bear":
                transform.GetChild(3).GetComponent<BearTower>().lvlSpeed = 0;
                transform.GetChild(3).GetComponent<BearTower>().lvlBreak = 0;
                transform.GetChild(3).GetComponent<BearTower>().Start();
            break;
            default: break;
        }
    }
}
