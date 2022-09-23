using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Money : MonoBehaviour
{
    static public int money = 1;
    public float speedMoney = 5f;
    public float maxSpeedMoney = 5f;
    public GameObject moneyPanel;
    GameObject bar;
    GameObject count;
    public TextMeshProUGUI txt; 
    bool can = true;

    private void Start()
    {
        speedMoney = maxSpeedMoney;
    }

    void Update()
    {        
        moneyPanel.transform.GetChild(0).gameObject.GetComponent<Image>().fillAmount = speedMoney/maxSpeedMoney;
        txt.text = money.ToString();
        if (can) StartCoroutine(mon());
    }

    IEnumerator mon()
    {
        can = false;
        yield return new WaitForSeconds(0.05f);
        speedMoney -= 0.05f;
        if (speedMoney <= 0)
        {
            speedMoney = maxSpeedMoney;
            money++;
        }
        can = true;
    }
}
