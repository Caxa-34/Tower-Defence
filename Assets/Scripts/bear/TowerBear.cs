using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBear : MonoBehaviour
{
    public Transform startBullet; 
    public Animator animBody, animStone;
    public float damage;

    public float breakResist = 0.3f;
    public float speedBullet;
    public GameObject bullet;
    public Transform target;
    public bool isShoot = false;

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
        animStone.Play("StoneCast");
        animBody.Play("BearCast");
        yield return new WaitForSeconds(0.8f);
        GameObject bul = GameObject.Instantiate(bullet, startBullet.position, Quaternion.identity) as GameObject;
        bul.GetComponent<BulletBear>().target = target;
        bul.GetComponent<BulletBear>().breakResist = breakResist;
        bul.GetComponent<BulletBear>().damage = damage;
        target = null;
        yield return new WaitForSeconds(speedBullet - 0.8f);
        isShoot = false;
    }
}
