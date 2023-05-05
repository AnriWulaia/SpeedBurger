using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonControllerScript : MonoBehaviour
{
    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    private void Update()
    {
        if (Time.timeScale == 0)
        {
            button.interactable = false;
        }
        else
        {
            button.interactable = true;
        }
    }
}
