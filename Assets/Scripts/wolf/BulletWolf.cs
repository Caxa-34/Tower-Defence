using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletWolf : MonoBehaviour
{
    public Transform target;
    public int damage;

    // Update is called once per frame
    void Update()
    {
        if (target) 
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime*20f);
            if (target.position == transform.position)
            {
                target.gameObject.GetComponent<hpEnemy>().Dmg(damage);
                Destroy(gameObject);
            }
        }
        if (!target) Destroy(gameObject);
    }
}
