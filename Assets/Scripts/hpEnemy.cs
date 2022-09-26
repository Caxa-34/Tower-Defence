using UnityEngine;
using UnityEngine.UI;

public class hpEnemy : MonoBehaviour
{
    public float hp;
    public float maxhp;
    public float resist = 0;
    public bool isresist = false;

    private void Start()
    {
        hp = maxhp;    
    }

    void Update()
    {
        if (hp <= 0)
        {
            WaveSpawn.countOnMap--;
            if (hp > -100) WaveSpawn.score += 10;
            Destroy(gameObject);
        }
    }
    public void Dmg(int damage)
    {
        hp -= damage * (1f - resist);
    }
}
