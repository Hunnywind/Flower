using UnityEngine;
using System.Collections;

public class CSound : MonoBehaviour {

    public AudioClip _pangSound;
    public AudioSource _audioSource;

    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
