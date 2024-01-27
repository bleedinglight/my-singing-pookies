using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PookieData : MonoBehaviour
{
    public bool pookieActive;
    public int pookieID;
    private AudioSource audioSource;

    private Animator animator;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if(this.GetComponent<Animator>() != null)   
        {
            animator = this.GetComponent<Animator>();
        }
    }

    public void PlayAudio()
    {
        if (pookieActive == true)
        {
            Debug.Log("FUCKING DO IT");
            if (!audioSource.isPlaying) 
            {
                audioSource.Play();
            }
            
        }
    }

    void Update() 
    {
        if (this.GetComponent<Animator>() != null) 
        {
            if (pookieActive == true)
            {
                animator.SetBool("pookieActive", true);
            } 
            else 
            {
                animator.SetBool("pookieActive", false);
            }
        }
    }
}
