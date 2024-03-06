using UnityEngine;
using UnityEngine.SceneManagement;

using static GameData;

public class RestartButtonManager : MonoBehaviour
{
    private bool isRestartButtonSoundPlay = false;
    private AudioSource RestartAudioSource;

    public AudioClip RestartAudioClip;

    void Start()
    {
        RestartAudioSource = gameObject.AddComponent<AudioSource>();

        RestartAudioSource.clip =  RestartAudioClip;
        RestartAudioSource.volume = SEVolume;
    }

    void Update()
    {
        if(isRestartButtonTap)
        {
            if(!isRestartButtonSoundPlay)
            {
                RestartAudioSource.Play();
                isRestartButtonSoundPlay = true;
            }
            else if(!RestartAudioSource.isPlaying)
            {
                SceneManager.LoadScene("Title");
                isRestartButtonTap = false;
            }
        }
    }
}
