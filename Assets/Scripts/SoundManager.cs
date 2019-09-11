using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    public AudioClip itemPickUpSound;
    public AudioClip[] TrackLevels;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = TrackLevels[0];
    }

    public void PlayPickupItemClip() {
        audioSource.PlayOneShot(itemPickUpSound);
    }
    
}
