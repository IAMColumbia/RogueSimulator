using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager _instance;
    [SerializeField] private AudioSource audioSource;

    public static AudioManager Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.LogError("AudioManger Not Found");
            }
            return _instance;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _instance = this;
    }

    public void PlayCalledClipOnce(AudioClip clip)
    {
        if (clip != null && audioSource != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}
