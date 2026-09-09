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
    [SerializeField] float FloatSpd = 4;
    [SerializeField] float Stamina = 100;
    [SerializeField] float Stamina_Depleation = 0.1f;
    [SerializeField] float Stamina_Recovery = 0.1f;
    float Max_stamina;

    private Animator WizardAnimator;
    [SerializeField] ParticleSystem FloatParticle;
    //  [SerializeField] float HowOftenSelfRight = 4;

    Vector2 movmentVector;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        WizardAnimator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        Max_stamina = Stamina;
    }

    // Update is called once per frame
    void Update()
    {

        // changes movment vector and wether sprite should be flipped depending on what key is pressed
        if (Input.GetKey(KeyCode.D))
        {
            movmentVector = new Vector2(1,0);
            sprite.flipX = false;
            WizardAnimator.SetBool("Running", true);
        }
       else if (Input.GetKey(KeyCode.A))
       {
            movmentVector = new Vector2(-1, 0);
            sprite.flipX = true;
            WizardAnimator.SetBool("Running", true);
        }
       else
       {
            movmentVector = new Vector2(0,0);
            WizardAnimator.SetBool("Running", false);
        }

        // vertical velocity checks that determine sprite animation based on if the player is going up or down
        if (rb.linearVelocityY < -0.1f)
        {
            WizardAnimator.SetBool("Falling", true);
            WizardAnimator.SetBool("Rising", false);
        }
        else if (rb.linearVelocityY > 0.1f)
        {
            WizardAnimator.SetBool("Falling", false);
            WizardAnimator.SetBool("Rising", true);
            if (Random.Range(0, 31) == 3)FloatParticle.Emit(1);
        }
        else
        {
            WizardAnimator.SetBool("Falling", false);
            WizardAnimator.SetBool("Rising", false);
        }
            
    }


    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space) && Stamina > 10)
        {
            rb.AddForceY(Jump);
            if (rb.linearVelocityY > FloatSpd) { rb.linearVelocityY = FloatSpd; }
            Stamina -= Stamina_Depleation * Time.deltaTime;
            // sets stamina to 0 if stamina enters negatives 
            if (Stamina < 0) { Stamina = 0; }

            print(Stamina);
        }
        else
        {
            Stamina += Stamina_Recovery * Time.deltaTime;
            if (Stamina > Max_stamina) { Stamina = Max_stamina; }
        }

        // applies movmnet vector and force applied to y to players rb.linearVelocity
        // we use .LinearVelocity rather then .MovePosition because it takes account for the forces already
        //being applied to the object
        rb.linearVelocity = new Vector2(movmentVector.x * Speed, rb.linearVelocity.y);


        if (transform.rotation.z != transform.up.z + 20  || transform.rotation.z != transform.up.z - 20)
        {
           // print("hjshd");
            float TragetAngle = Mathf.MoveTowardsAngle(rb.rotation, 0, RotationSpd * Time.fixedDeltaTime);

            rb.MoveRotation(TragetAngle);
        }
      
    }
   
}
