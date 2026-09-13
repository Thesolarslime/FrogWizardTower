using UnityEngine;
using UnityEngine.SceneManagement;

public class loadNextPannel : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void LoadNextPannel()
    {
        SceneManager.LoadScene("Cutscene2");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
