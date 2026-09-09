using UnityEngine;

public class PanThingToLeft : MonoBehaviour
{
    public float PanSpeed = -0.01f;
    public float DestroySelfTime = 50f;
    float elapsedTime = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PanSpeed = Random.Range(-0.002f, -0.007f);
        transform.position = transform.position - new Vector3(0, Random.Range(-3, 0.6f), 0);
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
