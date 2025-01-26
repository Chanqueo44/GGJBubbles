using UnityEngine;

public class AudioManager : MonoBehaviour {
    [Header("----------Audio Source------------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("----------Audio Clips------------")]
    
    public AudioClip background;
    public AudioClip death;
    public AudioClip hit;
    public AudioClip recover;


    private void Start(){
        musicSource.clip=background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip){
        SFXSource.PlayOneShot(clip);
    }

    public void PlayMusic(AudioClip clip){
         musicSource.clip=clip;
        musicSource.Play();
    }

}
