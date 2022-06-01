using UnityEngine;
using System.Collections;

public class BasicDestroyable : MonoBehaviour, IHittable, SendData
{
    [SerializeField]int hp;
    [SerializeField] DamageData.WeaponType typeReq;

    [SerializeField] MissionData _data;

    public MissionData data { get { return _data; } }

    public void TakeDamage(DamageData damage)
    {
        if(damage.type >= typeReq)
        {
            int damageMultiplier = damage.type - typeReq + 1;
            hp -= damage.damage * damageMultiplier;

            if (hp < 0)
            {
                MissionDataManager.Instance.AddData(data);
                AudioManager.Instance.Play("Glass");
                Destroy(gameObject);
            }
        }
    }
}
