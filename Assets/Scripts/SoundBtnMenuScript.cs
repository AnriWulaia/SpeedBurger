using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SoundBtnMenuScript : MonoBehaviour
{
    public Toggle musicToggle;
    public AudioSource musicSource;
    public Image musicImage;
    public Sprite musicOnSprite;
    public Sprite musicOffSprite;

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
        }
        else
        {
            musicSource.Stop();
            musicImage.sprite = musicOffSprite;
        }

        PlayerPrefs.SetInt("music", isMusicOn ? 1 : 0);
    }
}
