using UnityEngine;

public class PanThingToLeft : MonoBehaviour
{
    public float PanSpeed = -0.01f;
    public float DestroySelfTime = 50f;
    float elapsedTime = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PanSpeed = -0.002f;
        DestroySelfTime = 50f;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += new Vector3(PanSpeed,0,0);

        elapsedTime += Time.deltaTime;
        if (elapsedTime > DestroySelfTime)
        {
            Destroy(this.gameObject);
        }


    }
}
