using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBear : MonoBehaviour
{
    public Transform target;

    // Update is called once per frame
    void Update()
    {
        if (target) transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime*10f);
        if (transform.position == target.position) target.gameObject.GetComponent<hpEnemy>().Dmg(5);   
    }
}
