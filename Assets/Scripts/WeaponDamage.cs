using System.Collections.Generic;
using UnityEngine;

public class WeaponDamage : MonoBehaviour
{
    public PolygonCollider2D DamageArea;
    public int Damage;

    public ParticleSystem FireParticle;

    public List<Collider2D> DamageList = new List<Collider2D> ();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Fire();
        }
    }

    public void Fire()
    {
        FireParticle.Play();
        foreach (Collider2D Hit in DamageList)
        {
            if (Hit.GetComponent<Health>() != null)
            {
                /*if (Hit.GetComponent<Health>().HP - Damage < 1)
                {
                    DamageList.Remove(Hit);
                }*/
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
