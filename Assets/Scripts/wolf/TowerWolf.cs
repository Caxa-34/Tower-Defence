using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerWolf : MonoBehaviour
{
    public Transform startBullet; 
    public Animator anim;
    public int damage = 5;
    public float speedBullet;
    public GameObject bullet;
    public Transform target;
    bool isShoot = false;

    bool shoot1 = true;

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
        if (shoot1)
        {
            shoot1 = false;
            anim.Play("Shoot1");
        }
        else
        {
            shoot1 = true;
            anim.Play("Shoot2");
        }

        GameObject bul = GameObject.Instantiate(bullet, startBullet.position, Quaternion.identity) as GameObject;
        bul.GetComponent<BulletWolf>().target = target;
        bul.GetComponent<BulletWolf>().damage = damage;
        yield return new WaitForSeconds(speedBullet);
        isShoot = false;
    }
}
