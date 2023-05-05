using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour
{
    private int clickCount;
    public GameObject soundButton;
    public GameObject replayButton;
    Animator soundAnim;
    Animator replayAnim;
    public Sprite playImg;
    public Sprite pauseImg;
    Image buttonImage;
    public bool paused;
    


    private void Awake() {
        soundAnim = soundButton.GetComponent<Animator>();
        replayAnim = replayButton.GetComponent<Animator>();
        soundAnim.updateMode = AnimatorUpdateMode.UnscaledTime;
        replayAnim.updateMode = AnimatorUpdateMode.UnscaledTime;
        clickCount = 0;
        buttonImage = GetComponent<Image>();
        paused = false;
    }
    public void openMenu(){
        clickCount++;
        if(clickCount == 1){
            soundButton.SetActive(true);
            replayButton.SetActive(true);
            Time.timeScale = 0;
            buttonImage.sprite = playImg;
            paused=true;
        }
        if(clickCount > 1 && clickCount % 2 == 0){
            soundAnim.SetBool("ButtonOn", true);
            replayAnim.SetBool("replayOn", true);
            Time.timeScale = 1;
            buttonImage.sprite = pauseImg;
            paused=false;
        }else if(clickCount > 1 && clickCount % 2 == 1){
            Time.timeScale = 0;
            soundAnim.SetBool("ButtonOn", false);
            replayAnim.SetBool("replayOn", false);
            buttonImage.sprite = playImg;
            paused=true;
        }
    }
}
