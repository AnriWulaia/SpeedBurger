using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SoundsGameScript : MonoBehaviour
{
    public Toggle musicToggle;
    public AudioSource musicSource;
    public Image musicImage;
    public Sprite musicOnSprite;
    public Sprite musicOffSprite;
    public UIElementsScript uiScript;
    public AudioSource transition;
    private bool isMusicOn;

    void Start()
    {
        isMusicOn = PlayerPrefs.GetInt("music", 1) == 1;
        musicToggle.isOn = isMusicOn;
        if (isMusicOn)
        {
            musicSource.Play();
            musicImage.sprite = musicOnSprite;
        }
        else
        {
            musicSource.Stop();
            musicImage.sprite = musicOffSprite;
        }
    }

    public void ToggleMusic()
    {
        isMusicOn = musicToggle.isOn;

        if (isMusicOn)
        {
            musicSource.Play();
            musicImage.sprite = musicOnSprite;
            uiScript.btnClickSound.mute = false;
            uiScript.btnFailSound.mute = false;
            uiScript.loseSound.mute=false;
            transition.mute=false;
        }
        else
        {
            musicSource.Stop();
            musicImage.sprite = musicOffSprite;
            uiScript.btnClickSound.mute = true;
            uiScript.btnFailSound.mute = true;
            uiScript.loseSound.mute=true;
            transition.mute=true;
        }

        PlayerPrefs.SetInt("music", isMusicOn ? 1 : 0);
    }
}
