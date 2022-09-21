using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRabbit : MonoBehaviour
{
    public Transform target1;
    public Transform target2;

    // Update is called once per frame
    void Update()
    {
        if (target1 && target2)
        {
            transform.position = Vector3.Lerp(target1.position, target2.position, 0.5f);
            transform.LookAt(target2.position);  
        }
                
    }
}
