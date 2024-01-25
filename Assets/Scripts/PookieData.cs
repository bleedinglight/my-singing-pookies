using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PookieData : MonoBehaviour
{
    public bool pookieActive;
    public int pookieID;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayAudio()
    {
        if (pookieActive == true)
        {
            audioSource.PlayOneShot(audioSource.clip);
        }
    }
}
