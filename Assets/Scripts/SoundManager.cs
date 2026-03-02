using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    [SerializeField] AudioClip[] audioClips;
    [SerializeField] BirdScript birdScript;

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
        if (birdScript.isAlive)
        {
            myAudioSource.PlayOneShot(audioClips[2]);
        }
    }

    public void playFalling ()
    {
        myAudioSource.PlayOneShot(audioClips[3]);
    }

    public void playSwoosh ()
    {
        myAudioSource.PlayOneShot(audioClips[4]);
    }


}
