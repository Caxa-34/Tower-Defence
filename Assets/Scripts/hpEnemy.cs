using UnityEngine;
using UnityEngine.UI;

public class hpEnemy : MonoBehaviour
{
    public string type;
    public float hp;
    GameObject objHP, objBreak;
    public GameObject pref100hp, pref80hp, pref60hp, pref40hp, pref20hp, prefBreak;
    public float maxhp;
    public float resist = 0;
    public bool isResist = false;

    private void Start()
    {
        hp = maxhp;
        objHP = GameObject.Instantiate(pref100hp, GetComponent<Transform>().position, Quaternion.identity) as GameObject;
    }

    void Update()
    {
        if (hp <= 0)
        {
            WaveSpawn.countOnMap--;
            if (hp > -100) WaveSpawn.score += 10;
            Destroy(gameObject);
            Destroy(objHP); 
            Destroy(objBreak);
            return;
        }
        objHP.transform.position = GetComponent<Transform>().position;
        float scale = 100f;
        switch (type)
        {
            case "1":
                objHP.transform.position += new Vector3(0, 1.2f, 0);
                break;
            case "2":
                objHP.transform.position += new Vector3(0, 1.4f, 0);
                scale *= 1.2f;
                break;
            case "3":
                objHP.transform.position += new Vector3(0, 1.6f, 0);
                scale *= 1.8f;
                break;
            case "4":
                objHP.transform.position += new Vector3(0, 2.8f, 0);
                scale *= 2.2f;
                break;    
        }
        objHP.transform.rotation = Quaternion.Euler(0, 90, 90);
        objHP.transform.localScale = new Vector3(scale, scale, scale);
        if (isResist)
        {
            objBreak.transform.position = GetComponent<Transform>().position;
            switch (type)
            {
                case "1":
                    objBreak.transform.position += new Vector3(0, 1.5f, 0);
                    break;
                case "2":
                    objBreak.transform.position += new Vector3(0, 1.7f, 0);
                    break;
                case "3":
                    objBreak.transform.position += new Vector3(0, 2f, 0);
                    break;
                case "4":
                    objBreak.transform.position += new Vector3(0, 3.2f, 0);
                    break;
            }
            objBreak.transform.rotation = Quaternion.Euler(-90, 90, 90);
            objBreak.transform.localScale = new Vector3(scale, scale, scale);
        }
    }
    public void Dmg(float damage)
    {
        hp -= damage * (1f - resist);
        Destroy(objHP);
        double hpPercent = hp * 100 / maxhp; 
        if (hpPercent <= 100 & hpPercent > 80)
        {
            objHP = GameObject.Instantiate(pref100hp, GetComponent<Transform>().position, Quaternion.identity) as GameObject;
        }
        if (hpPercent <= 80 & hpPercent > 60)
        {
            objHP = GameObject.Instantiate(pref80hp, GetComponent<Transform>().position, Quaternion.identity) as GameObject;
        }
        if (hpPercent <= 60 & hpPercent > 40)
        {
            objHP = GameObject.Instantiate(pref60hp, GetComponent<Transform>().position, Quaternion.identity) as GameObject;
        }
        if (hpPercent <= 40 & hpPercent > 20)
        {
            objHP = GameObject.Instantiate(pref40hp, GetComponent<Transform>().position, Quaternion.identity) as GameObject;
        }
        if (hpPercent <= 20 & hpPercent > 0)
        {
            objHP = GameObject.Instantiate(pref20hp, GetComponent<Transform>().position, Quaternion.identity) as GameObject;
        }
        if (isResist)
        {
            Destroy(objBreak);
            objBreak = GameObject.Instantiate(prefBreak, GetComponent<Transform>().position, Quaternion.identity) as GameObject;
        }
    }
}
