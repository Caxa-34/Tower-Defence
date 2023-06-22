using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BearTower : MonoBehaviour
{
    public TextMeshProUGUI txtBreak, txtSpeed;
    public Image imageBreak, imageSpeed;
    public Sprite slvl0, slvl1, slvl2, slvl3;
    GameObject bear;

    public int lvlBreak = 0, lvlSpeed = 0;
    Sprite returnSprite(int level) {
        switch (level) {
            case 0: return slvl0;
            case 1: return slvl1;
            case 2: return slvl2;
            case 3: return slvl3;
        }
        return null;
    }

    public void upBreak()
    {
        if (lvlBreak == 3 || Money.money < 2) return;
        bear.GetComponent<TowerBear>().breakResist += 0.3f;
        lvlBreak++;
        Money.money -= 2;
        UpdateInfo();
    }

    public void upSpeed()
    {
        if (lvlSpeed == 3 || Money.money < 2) return;
        bear.GetComponent<TowerBear>().speedBullet -= 0.4f;
        lvlSpeed++;
        Money.money -= 2;
        UpdateInfo();   
    }

    public void UpdateInfo() {
        imageBreak.GetComponent<Image>().sprite = returnSprite(lvlBreak);
        imageSpeed.GetComponent<Image>().sprite = returnSprite(lvlSpeed);
        txtBreak.text = "Ослабление: " + bear.GetComponent<TowerBear>().breakResist.ToString();
        txtSpeed.text = "Скорость атаки: " + bear.GetComponent<TowerBear>().speedBullet.ToString();
    }
    // Start is called before the first frame update
    public void Start()
    {
        bear = transform.parent.gameObject.GetComponent<Place>().tower;
        UpdateInfo();
    }
}
