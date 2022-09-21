using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hpBase : MonoBehaviour
{
    public int hp = 10;
public GameObject loseWindow;
    

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            hp = 10;
            loseWindow.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
            hp--;
            other.gameObject.GetComponent<hpEnemy>().hp = 0;
    }
}
