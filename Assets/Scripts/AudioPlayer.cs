using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public AudioSource Audio;
    public AudioClip[] Clips;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound(int clip, float volume, bool pitchshift)
    {
        Audio.clip = Clips[clip];
        if (pitchshift)
        {
            Audio.pitch = Random.Range(1.1f, 0.9f);
        }
        else
        {
            Audio.pitch = 1;
        }
        Audio.volume = volume;
        Audio.Play();
    }
}
