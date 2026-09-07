using System;
using System.Collections;
using UnityEngine;

public class Health
{
    public int HP;
    public int MaxHP;

    public string Type;

    public int TileUnlockedAtLevel; //prevents damage to this until the player is this level or higher (used for lower tower tiles)


    public SpriteRenderer Sprite;
    public ParticleSystem DeathParticle;
    public ParticleSystem HurtParticle;


    public void Damage(int Damage)
    {
        HP -= Damage;
        if (HP < 1)
        {
            Die();
        }
        else
        {
            
        }
    }

    public void Die()
    {

    }

    private IEnumerator RedPulse()
    {
        Sprite.color = Color.red;
        yield return null;
        //yield return WaitForSeconds(0.1f);
        Sprite.color = Color.white;
    }
}
