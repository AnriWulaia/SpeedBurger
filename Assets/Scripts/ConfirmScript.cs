using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmScript : MonoBehaviour
{
    public InputField inputField;
    public ScoreBoardScriipt scoreScript;
    public void confirm(){
        string name = inputField.text;
        PlayerPrefs.SetString("name", name);
        scoreScript.updateName();
    }
}
