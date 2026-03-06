using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    [SerializeField] AudioClip[] audioClips;
    public bool isAlive = true;
    private AudioSource myAudioSource;
    // public static SoundManagerScript instance;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    } 

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
        if (isAlive)
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
