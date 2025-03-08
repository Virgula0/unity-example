using UnityEngine;

public class SoundScript : MonoBehaviour
{

    [SerializeField] // we do not break visibility and we let this to be available in unity inspector
    private AudioSource backgroundAudio;

    [SerializeField] 
    private AudioSource soundTrack;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        backgroundAudio.Play();
        soundTrack.Play();
    }
}
