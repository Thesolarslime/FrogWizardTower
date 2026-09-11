using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Health : MonoBehaviour
{
    public int HP;
    public int MaxHP;

    public string Type;

    public int TileUnlockedAtLevel; //prevents damage to this until the player is this level or higher (used for lower tower tiles)


    public SpriteRenderer Sprite;
    private AudioPlayer Audio;
    public ShadowCaster2D Shadow;
    public BoxCollider2D Collider;
    public ParticleSystem DeathParticle;
    public ParticleSystem HurtParticle;

    private void Start()
    {
        Audio = GetComponent<AudioPlayer>();
    }
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
            Audio.PlaySound(1, 0.3f, true);
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
            Shadow.enabled = false;
            Audio.PlaySound(2, 0.3f, true);
            DeathParticle.Play();
        }
        if (Type == "Enemy")
        {
            Collider.enabled = false;
            Sprite.enabled = false;
            Collider.gameObject.GetComponent<Rigidbody2D>().simulated = false;
            DeathParticle.Play();
            Audio.PlaySound(2, 0.5f, true);
            StartCoroutine(EnemyDie());
        }
        if (Type == "Explosive")
        {
            Collider.enabled = false;
            Sprite.enabled = false;
            Collider.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            Collider.gameObject.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
            DeathParticle.Play();
            Audio.PlaySound(2, 0.5f, true);
            gameObject.GetComponent<PointEffector2D>().forceMagnitude = 100;
            gameObject.GetComponent<Explosion>().Explode();
            StartCoroutine(EnemyDie());
        }
    }

    private IEnumerator RedPulse()
    {
        Sprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        Sprite.color = Color.white;
    }

    private IEnumerator EnemyDie()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
