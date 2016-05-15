using UnityEngine;
using System.Collections;

public class CSound : MonoBehaviour {

    public enum SOUND { SEEDTOUCH, BLOOM, MEETSBEE, SEEDSPHERE, GROWTOUCH, BEE };

    public SOUND _soundClip = SOUND.SEEDTOUCH;

    public AudioClip[] _sound;
    public AudioSource _audioSource;

    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void OneShotSound(SOUND clip, Vector3 tr)
    {
        transform.position = tr;
        _audioSource.PlayOneShot(_sound[(int)clip], 1.0f);
    }
}
