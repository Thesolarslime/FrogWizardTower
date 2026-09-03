using UnityEngine;
using UnityEngine.InputSystem;

public class PointTowardsMouse : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // converts mouse position on screen into global world position
        Vector3 MousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.value);

        // you can figure out a position relative to the objects position by - the postion from the objects position.
        // normalsing keeps speed consistant no matter where the direction is
        Vector2 Direction = (MousePos - transform.position).normalized;

        // rotate the GameObject so that its upward axis points towards the direction vector.
        transform.up = Direction;
    }
}
