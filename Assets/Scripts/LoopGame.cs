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
        if (SceneManager.GetActiveScene().name == "TobyTest")
        {
            SceneManager.LoadScene("TobyTest");
        }
        if (SceneManager.GetActiveScene().name == "Cutscene")
        {
            SceneManager.LoadScene("Cutscene2");
        }
        if (SceneManager.GetActiveScene().name == "Cutscene2")
        {
            SceneManager.LoadScene("TobyTest");
        }
    }

   
    // Update is called once per frame
    void Update()
    {
        
    }
}
