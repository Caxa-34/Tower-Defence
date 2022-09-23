using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hpEnemy : MonoBehaviour
{
    public float hp;
    public float maxhp;
    public float resist = 0;

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            WaveSpawn.countOnMap--;
            Destroy(gameObject);
        }
    }
    public void Dmg(int damage)
    {
        hp -= damage * (1f - resist);
    }
}
