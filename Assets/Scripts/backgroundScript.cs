using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class backgroundScript : MonoBehaviour, IPointerClickHandler
{
    private UIElementsScript uiscript;
    public GameObject spawner;
    public GameObject lostText;

    void Start() {
        uiscript = FindObjectOfType<UIElementsScript>();
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject == gameObject && uiscript.lostGame)
        {
            uiscript.lostGame = false;
            uiscript.timer.SetTrigger("TimerOn");
            spawner.SetActive(true);
            lostText.SetActive(false);
            uiscript.hasPlayedSound = false;
            uiscript.score.text = 0.ToString();
        }
    }
}
