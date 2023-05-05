using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderBoardScript : MonoBehaviour
{
    public GameObject dialogBox;
    public GameObject darkBack;
    public Transform box;

    private void Awake() {
        LeanTween.reset();
    }

    public void Open() {
        dialogBox.SetActive(true);
        darkBack.SetActive(true);
        box.localPosition = new Vector2(0, -Screen.height);
        box.LeanMoveLocalY(0,0.6f).setEaseInOutExpo();
    }

}
