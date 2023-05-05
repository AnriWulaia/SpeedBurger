
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIElementsScript : MonoBehaviour, IPointerClickHandler
{
    public SpawnIngredients spawn;
    private GameObject previousClickedButton;
    static int buttonChangeCount = 0;
    public bool endGame = false;
    public GameObject gameController;
    public GameObject parentObject;
    public RuntimeAnimatorController animatorController;
    public Animator timer;
    public GameObject timerBar;
    public Text score;
    public GameObject youLost;
    public int points;
    public bool lostGame = false;
    public AudioSource btnClickSound;
    public AudioSource btnFailSound;
    public AudioSource loseSound;
    public bool hasPlayedSound = false;
    public PauseScript pause;



    private void OnEnable() {
        GameObject scoreTextObj = GameObject.FindWithTag("score");
        score = scoreTextObj.GetComponent<Text>();
        buttonChangeCount = 0;
        points = 0;
        lostGame = false;
        makeZero();
    }
    
    private void FixedUpdate() {
        if(timerBar.transform.localScale.x <= 0.01 && !endGame){
            lostGame = true;
            foreach (Transform child in parentObject.transform) {
                GameObject.Destroy(child.gameObject);
            }
            if (!hasPlayedSound)
            {
                loseSound.Play();
                hasPlayedSound = true;
            }
            gameController.SetActive(false);
            youLost.SetActive(true);
            buttonChangeCount = 0;
            makeZero();
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        GameObject clickedButton = eventData.pointerCurrentRaycast.gameObject;
        if(!pause.paused){
            if (clickedButton.CompareTag("breadUI"))
            {   
                GameObject[] bread = GameObject.FindGameObjectsWithTag("breadDown");
                if(bread != null && buttonChangeCount == spawn.randomNumber + 1){
                    bread[1].GetComponent<Animator>().enabled = true;
                    SpriteRenderer spriteRenderer = bread[1].GetComponent<SpriteRenderer>();
                    spriteRenderer.color = new Color(1f,1f,1f,1f);
                    StartCoroutine(waitForDestroy());
                    btnClickSound.Play();
                }
                
                if (bread != null && bread.Length != 0 && buttonChangeCount == 0){
                    bread[0].GetComponent<Animator>().enabled = true;
                    SpriteRenderer spriteRenderer = bread[0].GetComponent<SpriteRenderer>();
                    spriteRenderer.color = new Color(1f,1f,1f,1f);
                    buttonChangeCount++;
                    btnClickSound.Play();
                }
                
            }
            else if(clickedButton.CompareTag("meatUI") && spawn.SpawnedObjects[buttonChangeCount] == "meat")
            {
                GameObject[] meat = GameObject.FindGameObjectsWithTag("meat");
                int countMeat = PlayerPrefs.GetInt("countMeat");
                meat[countMeat].GetComponent<Animator>().enabled = true;
                SpriteRenderer spriteRenderer = meat[countMeat].GetComponent<SpriteRenderer>();
                spriteRenderer.color = new Color(1f,1f,1f,1f);
                countMeat++;
                PlayerPrefs.SetInt("countMeat", countMeat);
                buttonChangeCount++;
                btnClickSound.Play();

            }else if(clickedButton.CompareTag("cheeseUI") && spawn.SpawnedObjects[buttonChangeCount] == "cheese")
            {
                GameObject[] cheese = GameObject.FindGameObjectsWithTag("cheese");
                int countCheese = PlayerPrefs.GetInt("countCheese");
                cheese[countCheese].GetComponent<Animator>().enabled = true;
                SpriteRenderer spriteRenderer = cheese[countCheese].GetComponent<SpriteRenderer>();
                spriteRenderer.color = new Color(1f,1f,1f,1f);
                countCheese++;
                PlayerPrefs.SetInt("countCheese", countCheese);
                buttonChangeCount++;
                btnClickSound.Play();
            }else if(clickedButton.CompareTag("lettuceUI") && spawn.SpawnedObjects[buttonChangeCount] == "lettuce")
            {
                GameObject[] lettuce = GameObject.FindGameObjectsWithTag("lettuce");
                int countLettuce = PlayerPrefs.GetInt("countLettuce");
                lettuce[countLettuce].GetComponent<Animator>().enabled = true;
                SpriteRenderer spriteRenderer = lettuce[countLettuce].GetComponent<SpriteRenderer>();
                spriteRenderer.color = new Color(1f,1f,1f,1f);
                countLettuce++;
                PlayerPrefs.SetInt("countLettuce", countLettuce);
                buttonChangeCount++;
                btnClickSound.Play();
            }else if(clickedButton.CompareTag("tomatoUI") && spawn.SpawnedObjects[buttonChangeCount] == "tomato")
            {
                GameObject[] tomato = GameObject.FindGameObjectsWithTag("tomato");
                int countTomato = PlayerPrefs.GetInt("countTomato");
                tomato[countTomato].GetComponent<Animator>().enabled = true;
                SpriteRenderer spriteRenderer = tomato[countTomato].GetComponent<SpriteRenderer>();
                spriteRenderer.color = new Color(1f,1f,1f,1f);
                countTomato++;
                PlayerPrefs.SetInt("countTomato", countTomato);
                buttonChangeCount++;
                btnClickSound.Play();
            }else if(clickedButton.CompareTag("onionUI") && spawn.SpawnedObjects[buttonChangeCount] == "onion")
            {
                GameObject[] onion = GameObject.FindGameObjectsWithTag("onion");
                int countOnion = PlayerPrefs.GetInt("countOnion");
                onion[countOnion].GetComponent<Animator>().enabled = true;
                SpriteRenderer spriteRenderer = onion[countOnion].GetComponent<SpriteRenderer>();
                spriteRenderer.color = new Color(1f,1f,1f,1f);
                countOnion++;
                PlayerPrefs.SetInt("countOnion", countOnion);
                buttonChangeCount++;
                btnClickSound.Play();
            }
        }
    }

    public void OnButtonClick()
    {
        Animator animator = GetComponent<Animator>();
        animator.Play("UIAnimations");
        if(!btnClickSound.isPlaying){
            btnFailSound.Play();
        }
        
    }
    private void endGameFunction(){
        if(endGame){
            foreach (Transform child in parentObject.transform) {
                GameObject.Destroy(child.gameObject);
            }
            gameController.SetActive(false);
            gameController.SetActive(true);
            endGame = false;
            timer.SetTrigger("Timer");
            score.text =  (int.Parse(score.text)+points).ToString();
            if (int.TryParse(score.text, out int highscore) && highscore > PlayerPrefs.GetInt("highscore", 0)) {
                PlayerPrefs.SetInt("highscore", highscore);
            }
        }
    }
    private IEnumerator waitForDestroy()
    {
        Animator animator = parentObject.GetComponent<Animator>();
        animator.runtimeAnimatorController = animatorController;
        animator.SetTrigger("FadeOut");
        endGame = true;
        yield return new WaitForSeconds(0.2f);
        points = 3 * (spawn.randomNumber-1);
        buttonChangeCount = 0;
        endGameFunction();
        makeZero();
    }
    private void makeZero(){
        PlayerPrefs.SetInt("countMeat", 0);
        PlayerPrefs.SetInt("countCheese", 0);
        PlayerPrefs.SetInt("countLettuce", 0);
        PlayerPrefs.SetInt("countTomato", 0);
        PlayerPrefs.SetInt("countOnion", 0);
    }
}
