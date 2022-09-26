using UnityEngine;

public class BulletWolf : MonoBehaviour
{
    public Transform target;
    public int damage;

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
        else Destroy(gameObject);
    }
}
