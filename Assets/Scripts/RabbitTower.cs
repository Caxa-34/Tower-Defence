using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RabbitTower : MonoBehaviour
{
    public TextMeshProUGUI txtDamage, txtCount;
    public Image imageDamage, imageCount;
    public Sprite slvl0, slvl1, slvl2, slvl3;
    GameObject rabbit;

    public int lvlDamage = 0, lvlCount = 0;
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
        rabbit.GetComponent<TowerRabbit>().damage += 0.4f;
        lvlDamage++;
        Money.money -= 2;
        UpdateInfo();
    }

    public void upCount()
    {
        if (lvlCount == 3 || Money.money < 2) return;
        rabbit.GetComponent<TowerRabbit>().countTarget += 1;
        lvlCount++;
        Money.money -= 2;
        UpdateInfo();   
    }

    public void UpdateInfo() {
        imageDamage.GetComponent<Image>().sprite = returnSprite(lvlDamage);
        imageCount.GetComponent<Image>().sprite = returnSprite(lvlCount);
        txtDamage.text = "Урон: " + rabbit.GetComponent<TowerRabbit>().damage.ToString();
        txtCount.text = "Длина поражения: " + rabbit.GetComponent<TowerRabbit>().countTarget.ToString();
    }
    // Start is called before the first frame update
    public void Start()
    {
        rabbit = transform.parent.gameObject.GetComponent<Place>().tower;
        UpdateInfo();
    }
}
