using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closeDialogScript : MonoBehaviour
{
    public GameObject dialogBox;
    public Transform box;
    public GameObject darkBack;
    public void closeDialog(){
        box.LeanMoveLocalY(-Screen.height,0.6f).setEaseInExpo();
        StartCoroutine(activeOff());
    }
    private IEnumerator activeOff(){
        yield return new WaitForSeconds(0.5f);
        darkBack.SetActive(false);
        dialogBox.SetActive(false);
    }
}
