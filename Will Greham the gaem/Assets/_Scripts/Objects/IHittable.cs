using UnityEngine;
using System.Collections;

public interface IHittable
{
    void TakeDamage(DamageData damage);
}
