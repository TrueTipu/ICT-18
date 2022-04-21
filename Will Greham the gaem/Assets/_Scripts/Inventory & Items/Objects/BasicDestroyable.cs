using UnityEngine;
using System.Collections;

public class BasicDestroyable : MonoBehaviour, IHittable
{
    [SerializeField]int hp;

    public void TakeDamage(DamageData damage)
    {
        if(damage.type == DamageData.WeaponType.Medium)
        {
            hp -= damage.damage;

            if (hp < 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
