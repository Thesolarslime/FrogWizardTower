using UnityEngine;
using UnityEngine.SceneManagement;

public class LoopGame : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void loopScene()
    {
        SceneManager.LoadScene("TobyTest");
    }

   
    // Update is called once per frame
    void Update()
    {
        
    }
}
