using UnityEngine;
using System.Collections;

public class BasicDestroyable : MonoBehaviour, IHittable
{
    [SerializeField]int hp;
    [SerializeField] DamageData.WeaponType typeReq;

    public void TakeDamage(DamageData damage)
    {
        if(damage.type >= typeReq)
        {
            int damageMultiplier = damage.type - typeReq + 1;
            hp -= damage.damage * damageMultiplier;

            if (hp < 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
