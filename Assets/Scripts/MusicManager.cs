using System.Collections;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip[] Tracks;
    private AudioSource Music;
    public int CurrentTrack = -1;

    public ParticleSystem WindParticles;
    public AreaEffector2D WindEffector;
    public Animator CameraStarryAnimator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Music = GetComponent<AudioSource>();
        CurrentTrack = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Music.isPlaying == false)
        {
            StartCoroutine(SwitchTrack());
        }
    }

    public IEnumerator SwitchTrack()
    {
        yield return new WaitForSeconds(0.1f);
        if (Music.isPlaying == false)
        {
            CurrentTrack++;
            Music.clip = Tracks[CurrentTrack];
            Music.Play();

            switch (CurrentTrack)
            {
                case 0:
                    break;
                case 1:
                    CameraStarryAnimator.SetBool("Starry", true);
                    break;
                case 2:
                    CameraStarryAnimator.SetBool("Starry", true);
                    WindParticles.Play();
                    WindEffector.forceMagnitude = 10;
                    break;
                case 3:
                    WindParticles.Stop();
                    WindEffector.forceMagnitude = 0;
                    break;
                case 4:
                    CameraStarryAnimator.SetBool("Starry", true);
                    WindParticles.Play();
                    WindEffector.forceMagnitude = 10;
                    break;
            }
        }
    }
}
