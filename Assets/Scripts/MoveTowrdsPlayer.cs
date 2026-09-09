using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class MoveTowrdsPlayer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    GameObject Player;
    Rigidbody2D RB;
    [SerializeField] float Speed = 4;
    [SerializeField] float RotationSpd = 2;
    float ElapsedTime = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player = GameObject.Find("TEMPwizard_0 (1)");
        RB = GetComponent<Rigidbody2D>();
    }


    // how knock back could work
    // could work by using on trigger then taking gameobjects position anwat from other to get a direction then apply force
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 CollisionPoint = collision.GetContact(0).point;
    }

    private void FixedUpdate()
    {
        Vector2 playerLocation = Player.transform.position;

        Vector2 MoveToVector = Vector2.MoveTowards(RB.position, playerLocation, Speed * Time.fixedDeltaTime);

        RB.MovePosition(MoveToVector);

        ElapsedTime += Time.deltaTime;

        if (ElapsedTime > 4)
        {
            StartCoroutine(LerpRotation(0));
            ElapsedTime = 0;
        }

    }

    IEnumerator LerpRotation(float TargetDegree)
    {

        Quaternion startValue = transform.rotation;

        while (transform.rotation.z != TargetDegree)
        {

            float TragetAngle = Mathf.MoveTowardsAngle(RB.rotation, TargetDegree, RotationSpd * Time.fixedDeltaTime);

            RB.MoveRotation(TragetAngle);

            yield return null;
        }
        // sets rotation velocity back to nothing after finished rotating
        RB.angularVelocity = 0f;

    }
}
