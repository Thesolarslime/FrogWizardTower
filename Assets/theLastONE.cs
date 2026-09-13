using UnityEngine;

public class theLastONE : MonoBehaviour
{

    public Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    float elapsedtime = 0f;
    // Update is called once per frame
    void Update()
    {
        elapsedtime += Time.deltaTime;

        if (elapsedtime > 4)
        {
            animator.SetTrigger("FadeOut");
        }
    }
}
