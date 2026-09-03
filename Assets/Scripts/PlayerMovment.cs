using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    [SerializeField] float Speed = 1.0f;
    [SerializeField] float Jump = 10.0f;
    Vector2 movmentVector;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForceY(Jump);
        }

        // changes movment vector and wether sprite should be flipped depending on what key is pressed
        if (Input.GetKey(KeyCode.D))
        {
            movmentVector = new Vector2(1,0);
            sprite.flipX = false;
        }
       else if (Input.GetKey(KeyCode.A))
       {
            movmentVector = new Vector2(-1, 0);
            sprite.flipX = true;
       }
       else
       {
            movmentVector = new Vector2(0,0);
       }
            
    }

    private void FixedUpdate()
    {

        // applies movmnet vector and force applied to y to players rb 
        rb.linearVelocity = new Vector2(movmentVector.x * Speed, rb.linearVelocity.y);
    }
}
