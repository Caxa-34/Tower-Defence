using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WolfTower : MonoBehaviour
{   
    public TextMeshProUGUI txtDamage, txtSpeed;
    public Image imageDamage, imageSpeed;
    public Sprite slvl0, slvl1, slvl2, slvl3;
    GameObject wolf;

    public int lvlDamage = 0, lvlSpeed = 0;
    Sprite returnSprite(int level) {
        switch (level) {
            case 0: return slvl0;
            case 1: return slvl1;
            case 2: return slvl2;
            case 3: return slvl3;
        }
        return null;
    }

    public void upDamage()
    {
        if (lvlDamage == 3 || Money.money < 2) return;
        wolf.GetComponent<TowerWolf>().damage += 0.4f;
        lvlDamage++;
        Money.money -= 2;
        UpdateInfo();
    }

    public void upSpeed()
    {
        if (lvlSpeed == 3 || Money.money < 2) return;
        wolf.GetComponent<TowerWolf>().speedBullet -= 0.1f;
        lvlSpeed++;
        Money.money -= 2;
        UpdateInfo();   
    }

    public void UpdateInfo() {
        imageDamage.GetComponent<Image>().sprite = returnSprite(lvlDamage);
        imageSpeed.GetComponent<Image>().sprite = returnSprite(lvlSpeed);
        txtDamage.text = "Урон: " + wolf.GetComponent<TowerWolf>().damage.ToString();
        txtSpeed.text = "Скорость атаки: " + wolf.GetComponent<TowerWolf>().speedBullet.ToString();
    }
    // Start is called before the first frame update
    public void Start()
    {
        wolf = transform.parent.gameObject.GetComponent<Place>().tower;
        UpdateInfo();
    }
}
