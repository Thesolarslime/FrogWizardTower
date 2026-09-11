using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public List<Collider2D> DamageList = new List<Collider2D>();
    public int Damage;

    public void Explode()
    {
        foreach (Collider2D Hit in DamageList)
        {
            if (Hit.GetComponent<Health>() != null)
            {
                Hit.GetComponent<Health>().Damage(Damage);
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Health>() != null)
        {
            DamageList.Add(collision);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Health>() != null)
        {
            DamageList.Remove(collision);
        }
    }
}
