using UnityEngine;

public class BulletBear : MonoBehaviour
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
                if (!target.gameObject.GetComponent<hpEnemy>().isresist) target.gameObject.GetComponent<hpEnemy>().resist -= 0.3f;
                Destroy(gameObject);
            }
        }
        else Destroy(gameObject);
    }
}
