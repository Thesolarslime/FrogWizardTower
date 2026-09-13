using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreenLoop : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    float elapsedTime = 0;
    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime > 8f)
        {
            SceneManager.LoadScene("TobyTest");
        }
    }
}
