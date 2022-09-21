using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hpEnemy : MonoBehaviour
{
    public float hp;
    public float maxhp;
    public float resist = 0;
    public Image hpBarPref, hpBar;
    public GameObject canvas;

    private void Start()
    {
        hpBar = GameObject.Instantiate(hpBarPref, canvas.transform.position, Quaternion.identity) as Image;
        hpBar.rectTransform.SetParent(canvas.transform);    
    }

    // Update is called once per frame
    void Update()
    {
        hpBar.GetComponent<Image>().fillAmount = hp/maxhp;
        hpBar.rectTransform.position = Camera.main.WorldToScreenPoint(transform.position);
        if (hp <= 0)
        {
            WaveSpawn.countOnMap--;
            Destroy(gameObject);
            Destroy(hpBar);
        }
    }
    public void Dmg(int damage)
    {
        hp -= damage * (1f - resist);
    }
}
