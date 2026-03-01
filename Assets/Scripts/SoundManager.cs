using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    [SerializeField] AudioClip[] audioClips;

    private AudioSource myAudioSource;

    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }
    
    public void playFlap ()
    {
        myAudioSource.PlayOneShot(audioClips[0]);
    }

    public void playCoin ()
    {
        myAudioSource.PlayOneShot(audioClips[1]);
    }

    public void playCollision ()
    {
        myAudioSource.PlayOneShot(audioClips[2]);
    }

    public void playDeath ()
    {
        // myAudioSource.PlayDelayed(10);
        myAudioSource.PlayOneShot(audioClips[3]);
    }

    public void playSwoosh ()
    {
        myAudioSource.PlayOneShot(audioClips[4]);
    }


}
