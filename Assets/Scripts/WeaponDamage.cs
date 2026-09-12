using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDamage : MonoBehaviour
{
    public PolygonCollider2D DamageArea;
    public AreaEffector2D Knockback;
    public int Damage;
    public float coolDown = 0.5f;
    public ParticleSystem FireParticle;
    private AudioPlayer Audio;

    public List<Collider2D> DamageList = new List<Collider2D> ();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Audio = GetComponent<AudioPlayer>();
    }

    float elapsedTime = 0f;
    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Mouse0) && elapsedTime > coolDown)
        {
            Fire();
            elapsedTime = 0f;
        }
    }

    public void Fire()
    {
        FireParticle.Play();
        Audio.PlaySound(Random.Range(0,4), 0.15f, true);
        StartCoroutine(TempKnockback());
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

    public IEnumerator TempKnockback()
    {
        Knockback.forceMagnitude = 1000;
        yield return new WaitForSeconds(0.02f);
        Knockback.forceMagnitude = 800;
        yield return new WaitForSeconds(0.02f);
        Knockback.forceMagnitude = 600;
        yield return new WaitForSeconds(0.02f);
        Knockback.forceMagnitude = 400;
        yield return new WaitForSeconds(0.02f);
        Knockback.forceMagnitude = 200;
        yield return new WaitForSeconds(0.02f);
        Knockback.forceMagnitude = 0;
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
