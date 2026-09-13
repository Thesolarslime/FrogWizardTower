using UnityEngine;

public class AniControllerCutscene : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Animator animator1;
    public Animator animator2;
    public Animator animator3;
    public Animator Fade;
    void Start()
    {
        
    }
    public float textTimer = 8;
    int counter = 0;
    float elapsedTimer = 0;
    // Update is called once per frame
    void Update()
    {

        elapsedTimer += Time.deltaTime;

        if (counter == 0 && elapsedTimer > textTimer)
        {
            animator1.SetTrigger("down");
            animator2.SetTrigger("up");
            counter++;
            elapsedTimer = 0;

        }
        if (counter == 1 && elapsedTimer > textTimer)
        {
            animator2.SetTrigger("down");
            animator3.SetTrigger("up");
            counter++;
            elapsedTimer = 0;

        }
        if (counter == 2 && elapsedTimer > textTimer)
        {
            Fade.SetTrigger("FadeOut");
            elapsedTimer = 0;

        }
    }
}
