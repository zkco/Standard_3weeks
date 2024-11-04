using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Campfire : MonoBehaviour
{
    public int damage;
    public float damageRate;

    List<IDamagable> things = new List<IDamagable>();

    void Start()
    {
        InvokeRepeating("DealDamage", 0f, damageRate);
    }

    void Update()
    {
        
    }

    void DealDamage()
    {
        for (int i = 0; i < things.Count; i++)
        {
            things[i].TakePhysicalDamage(damage);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out IDamagable damageable))
        {
            things.Add(damageable);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out IDamagable damageable))
        {
            things.Remove(damageable);
        }
    }
}
