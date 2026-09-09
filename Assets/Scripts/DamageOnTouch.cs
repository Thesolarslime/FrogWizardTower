using Unity.VisualScripting;
using UnityEngine;

public class DamageOnTouch : MonoBehaviour
{
    public int TouchDamage = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
        }
    }
}
