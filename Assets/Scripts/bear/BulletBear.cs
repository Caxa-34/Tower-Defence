using UnityEngine;

public class BulletBear : MonoBehaviour
{
    public Transform target;
    public float damage;

    public float breakResist;
    
    void Update()
    {
        if (target) 
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime*15f);
            if (target.position == transform.position)
            {
                if (!target.gameObject.GetComponent<hpEnemy>().isResist)
                    target.gameObject.GetComponent<hpEnemy>().resist -= breakResist;
                target.gameObject.GetComponent<hpEnemy>().isResist = true;
                target.gameObject.GetComponent<hpEnemy>().Dmg(damage);
                Destroy(gameObject);
            }
        }
        else Destroy(gameObject);
    }
}
