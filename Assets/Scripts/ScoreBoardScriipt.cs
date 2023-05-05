using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreBoardScriipt : MonoBehaviour
{
    private Text firstPlace;
    int highscore;
    string nickname;

    private void OnEnable() {
        firstPlace = GetComponent<Text>();
        highscore = PlayerPrefs.GetInt("highscore",0);
        nickname = !string.IsNullOrEmpty(PlayerPrefs.GetString("name")) ? PlayerPrefs.GetString("name") : "UNKNOWN";
        firstPlace.text = ($"{nickname}-{highscore}PTS").ToString();
    }
    public void updateName(){
        highscore = PlayerPrefs.GetInt("highscore",0);
        nickname = !string.IsNullOrEmpty(PlayerPrefs.GetString("name")) ? PlayerPrefs.GetString("name") : "UNKNOWN";
        firstPlace.text = ($"{nickname}-{highscore}PTS").ToString();
    }
}
