using UnityEngine;
using System.Collections;

public class BasicDestroyable : MonoBehaviour, IHittable
{
    [SerializeField]int hp;

    public void TakeDamage(DamageData damage)
    {
        hp -= damage.damage;

        if(hp < 0)
        {
            Destroy(gameObject);
        }
    }
}
