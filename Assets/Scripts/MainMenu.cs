using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    [SerializeField] private GameObject settingsUI;
    [SerializeField] private GameObject mainText;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        timer = logoScreenTime;
        fadingIn = true;
        loading = true;
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
                PlayIntroSound();
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    fadingIn = false;
                    timer = logoScreenTime / 2;
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
                    mainText.SetActive(true);
                    loading = false;
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
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    bool introPlayed;
    public void PlayIntroSound()
    {
        if (!introPlayed)
        {
            audioSource.PlayOneShot(audioSource.clip);
            introPlayed = true;
        }
    }
}
