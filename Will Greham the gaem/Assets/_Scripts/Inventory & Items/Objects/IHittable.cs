using UnityEngine;
using System.Collections;

public interface IHittable
{
    public void TakeDamage(DamageData damage);
}
