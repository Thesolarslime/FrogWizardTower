using System;
using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int HP;
    public int MaxHP;

    public string Type;

    public int TileUnlockedAtLevel; //prevents damage to this until the player is this level or higher (used for lower tower tiles)


    public SpriteRenderer Sprite;
    public BoxCollider2D Collider;
    public ParticleSystem DeathParticle;
    public ParticleSystem HurtParticle;


    public void Damage(int Damage)
    {
        HP -= Damage;
        if (HP < 1)
        {
            StartCoroutine(Die());
        }
        else
        {
            StartCoroutine(RedPulse());
            HurtParticle.Play();
        }
    }

    public IEnumerator Die()
    {
        yield return new WaitForEndOfFrame();
        if (Type == "Tower")
        {
            Collider.enabled = false;
            Sprite.enabled = false;
            DeathParticle.Play();
        }
    }

    private IEnumerator RedPulse()
    {
        Sprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        Sprite.color = Color.white;
    }
}
