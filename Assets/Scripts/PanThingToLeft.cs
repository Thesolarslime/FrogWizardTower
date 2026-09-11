using UnityEngine;

public class PanThingToLeft : MonoBehaviour
{
    public float PanSpeed = -1.3f;
   
    void Start()
    {
        //PanSpeed = Random.Range(-2f, -1f);
        transform.position = transform.position - new Vector3(0, Random.Range(-3, 0.6f), 0);
       
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += new Vector3(PanSpeed * Time.deltaTime,0,0);
      
        if (transform.position.x <= -65)
        {
            Destroy(this.gameObject);
        }


    }
}
