using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class MainMenu : MonoBehaviour
{
    [SerializeField] private Image shitpissIndustriesLogo;
    [SerializeField] private float fadeSpeed;
    [SerializeField] private float logoScreenTime;
    private float timer;
    [SerializeField] private GameObject menuScreen;
    private bool fadingIn;
    private bool loading;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        timer = logoScreenTime;
        fadingIn = true;
    }

    private void Update()
    {
        if (loading)
        {  
            if (fadingIn && shitpissIndustriesLogo.color.a < 1)
            {
                FadeIn();
            }
            else if (fadingIn && shitpissIndustriesLogo.color.a >= 1)
            {
                audioSource.PlayOneShot(audioSource.clip);
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    fadingIn = false;
                    timer = logoScreenTime;
                }
            }
            else if (!fadingIn && shitpissIndustriesLogo.color.a > 0)
            {
                FadeOut();
            }
            else if (!fadingIn && shitpissIndustriesLogo.color.a <= 0)
            {
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    menuScreen.SetActive(true);
                }
            }
        }

    }

    void FadeIn()
    {
        Color myColor = new Color(shitpissIndustriesLogo.color.r, shitpissIndustriesLogo.color.g, shitpissIndustriesLogo.color.b, shitpissIndustriesLogo.color.a + fadeSpeed * Time.deltaTime);
        shitpissIndustriesLogo.color = myColor;
    }

    void FadeOut()
    {
        Color myColor = new Color(shitpissIndustriesLogo.color.r, shitpissIndustriesLogo.color.g, shitpissIndustriesLogo.color.b, shitpissIndustriesLogo.color.a - fadeSpeed * Time.deltaTime);
        shitpissIndustriesLogo.color = myColor;
    }

    public void StartGame()
    {

    }

    public void OpenSettings()
    {

    }
}
