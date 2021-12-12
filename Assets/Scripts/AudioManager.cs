
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] _Cnocks;
    [SerializeField] private AudioClip[] _Crashes;
    [SerializeField] private AudioClip[] _Victory;
    private AudioSource _audioSource;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayCnockSound()        //play random sound from Cnocks
    {
        _audioSource.pitch = Random.Range(0.95f, 1.05f);
        _audioSource.PlayOneShot(_Cnocks[Random.Range(0, _Cnocks.Length)]);
    }

    public void PlayCrashSound()        //play random sound from Crashes
    {
        _audioSource.pitch = Random.Range(0.95f, 1.05f);
        _audioSource.PlayOneShot(_Crashes[Random.Range(0, _Crashes.Length)]);
    }

    public void PlayVictorySound()      //play random sound from Victory
    {
        _audioSource.PlayOneShot(_Victory[Random.Range(0, _Victory.Length)]);
    }

}
