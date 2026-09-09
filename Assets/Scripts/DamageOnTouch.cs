using Unity.VisualScripting;
using UnityEngine;

public class DamageOnTouch : MonoBehaviour
{
    public int TouchDamage = 1;
    public bool DamageSelf;
    private Health Health;
    public AudioPlayer Audio;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Health = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Health>() != null)
        {
            collision.gameObject.GetComponent<Health>().Damage(TouchDamage);
            if (DamageSelf)
            {
                Health.Damage(TouchDamage);
            }
        }
        Audio.PlaySound(0, 0.5f, true);
    }
}
