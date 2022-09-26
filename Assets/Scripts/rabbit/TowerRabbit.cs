using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using PathCreation.Examples;

public class TowerRabbit : MonoBehaviour
{
    public Transform startBullet; 
    public Animator anim;
    public int damage = 5;
    public int countTarget = 2;
    List<GameObject> targets = new List<GameObject>();
    List<GameObject> lightings = new List<GameObject>();

    public float speedBullet;
    public GameObject bullet;
    public Transform target;
    bool isShoot = false;
    int i;
    void FixedUpdate()
    {

        if (target)
        {
            if (!isShoot)
            {
                StartCoroutine(Shoot());
            }

        }
    }

    IEnumerator Shoot()
    {
        isShoot = true;

   
        targets = GameObject.FindGameObjectsWithTag("enemy").ToList();

        for (i = 0; i < targets.Count; i++)
            if (targets[i].GetComponent<PathFollower>().distanceTravelled > target.gameObject.GetComponent<PathFollower>().distanceTravelled)
            {
                targets.RemoveAt(i);
                i--;
            }
        for (i = 0; i < targets.Count - 1; i++)
        {
            if (targets[i].GetComponent<PathFollower>().distanceTravelled - targets[i+1].GetComponent<PathFollower>().distanceTravelled > 3)
            {
                for (int j = i + 1; j < targets.Count; j++)
                {
                    targets.RemoveAt(j);
                    j--;
                }
                break;
            }
        }
        Debug.Log("Врагов " + targets.Count);
        for (i = 0; i < countTarget-1 && i < targets.Count - 1; i++)
        {
            lightings.Add(Instantiate(bullet) as GameObject);
            lightings[i].GetComponent<BulletRabbit>().target1 = targets[i].transform;
            lightings[i].GetComponent<BulletRabbit>().target2 = targets[i+1].transform;
        }
        for (i = 0; i < countTarget && i < targets.Count; i++) targets[i].gameObject.GetComponent<hpEnemy>().Dmg(damage);
        
        GameObject lighting = Instantiate(bullet, Vector3.Lerp(startBullet.position, targets[0].transform.position, 0.5f), Quaternion.identity);
        lighting.transform.LookAt(targets[0].transform);

        yield return new WaitForSeconds(0.2f);

        targets.Clear();
        for (i = 0; i < lightings.Count; i++) 
        {
            Destroy(lightings[i]);
        }
        lightings.Clear();
        Destroy(lighting);

        yield return new WaitForSeconds(speedBullet-0.2f);
        isShoot = false;
    }
}
