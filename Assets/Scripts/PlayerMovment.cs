using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PlayerMovment : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private float ElapsedTime = 0;  
    [SerializeField] float Speed = 1.0f;
    [SerializeField] float Jump = 10.0f;
    [SerializeField] float RotationSpd = 30;
    [SerializeField] float HowOftenSelfRight = 4;

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

        // applies movmnet vector and force applied to y to players rb.linearVelocity
        // we use .LinearVelocity rather then .MovePosition because it takes account for the forces already
        //being applied to the object
        
        rb.linearVelocity = new Vector2(movmentVector.x * Speed, rb.linearVelocity.y);


        // self rights player character periodicly, BUG how often self right var dosnt seem to work as expected
        ElapsedTime += Time.deltaTime;

        if (ElapsedTime > HowOftenSelfRight)
        {
            print("here");
            StartCoroutine(LerpRotation(0));
            ElapsedTime = 0;
        }

    }
    IEnumerator LerpRotation(float TargetDegree)
    {

        Quaternion startValue = transform.rotation;

        while (transform.rotation.z != TargetDegree || transform.rotation.z > 1 || transform.rotation.z < -1)
        {

            float TragetAngle = Mathf.MoveTowardsAngle(rb.rotation, TargetDegree, RotationSpd * Time.fixedDeltaTime);

            rb.MoveRotation(TragetAngle);
            
            yield return null;
        }
       // ElapsedTime = 0;
        // sets rotation velocity back to nothing after finished rotating
        

    }
}
