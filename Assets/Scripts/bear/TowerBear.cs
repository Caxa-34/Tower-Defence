using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBear : MonoBehaviour
{
    public Transform startBullet; 
    public Animator anim;
    public int damage = 5;
    public float speedBullet;
    public GameObject bullet;
    public Transform target;
    bool isShoot = false;

    void FixedUpdate()
    {
        if (target)
        {
            Vector3 targetV3 = new Vector3(target.position.x, transform.position.y, target.position.z);
            GetComponent<Transform>().transform.LookAt(targetV3);
            if (!isShoot)
            {
                StartCoroutine(Shoot());
            }
        }
    }

    IEnumerator Shoot()
    {
        isShoot = true;
        GameObject bul = GameObject.Instantiate(bullet, startBullet.position, Quaternion.identity) as GameObject;
        bul.GetComponent<BulletBear>().target = target;
        bul.GetComponent<BulletBear>().damage = damage;
        //anim.Play("StoneCast");
        yield return new WaitForSeconds(speedBullet);
        isShoot = false;
    }
}
