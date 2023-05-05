using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnIngredients : MonoBehaviour
{
    public GameObject[] prefabsToSpawn;
    public GameObject breadDown;
    public GameObject breadUp;
    public RectTransform uiElement;
    public string[] SpawnedObjects;
    private GameObject instantiatedObject;
    public int randomNumber;
    public GameObject parentObject;
    public UIElementsScript ui;
    public RuntimeAnimatorController animatorController;
    private static int count;
    private AudioSource burgerMade;

    private void OnEnable() {
        SpawnPrefab();
        burgerMade = GetComponent<AudioSource>();
    }

    public void SpawnPrefab()
    {
        if(ui.endGame){
            burgerMade.Play();
            Animator animator = parentObject.GetComponent<Animator>();
            animator.runtimeAnimatorController = animatorController;
            animator.SetTrigger("FadeIn");
  
        }
        
        count++;
        System.Random rnd = new System.Random();
        randomNumber = rnd.Next(3, 6);
        SpawnedObjects = new string[randomNumber+2];
        SpawnedObjects[0] = "breadDown";
        int randomIndex = Random.Range(0, prefabsToSpawn.Length);
        PlayerPrefs.SetInt("lastIndex", randomIndex);
        RectTransform uiRectTransform = uiElement.GetComponent<RectTransform>();
        float bottomY = uiRectTransform.position.y;


        Vector2 gameObjectPosition = new Vector2(0, bottomY + 2.5f);


        //Using height
        RectTransform rectTransform = uiElement.GetComponent<RectTransform>();
        float topY = rectTransform.rect.height;
        Vector3 screenPos = new Vector3(0, topY, 0f);
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
        float convertedY = worldPos.y;


        Vector2 uiSize = uiElement.rect.size * uiElement.lossyScale.x;

        Vector3 uiBottomCenter = uiElement.TransformPoint(uiElement.rect.center - new Vector2(0, uiSize.y / 2));
        float yPos = 0;


        float parentX = parentObject.transform.position.x;

        switch (randomNumber)
        {
            
            case 3:
                if(Screen.height > 1335){
                    yPos = uiBottomCenter.y - uiBottomCenter.y / 2 + 0.85f;
                }else{
                    yPos = -convertedY / 2 + breadDown.GetComponent<SpriteRenderer>().bounds.extents.y;
                }
                Instantiate(breadDown, new Vector2(parentX, yPos), Quaternion.identity).transform.parent = parentObject.transform;
                
                Instantiate(breadUp, new Vector2(parentX, yPos + 0.7f * (randomNumber + 1) + 0.1f), Quaternion.identity).transform.parent = parentObject.transform;
                for(int i = 1; i < randomNumber + 1; i++ ){
                    instantiatedObject = Instantiate(prefabsToSpawn[randomIndex], new Vector2(parentX, yPos) + new Vector2(0, i * 0.7f), Quaternion.identity);
                    SpawnedObjects[i] = instantiatedObject.tag;
                    instantiatedObject.transform.parent = parentObject.transform;
                    randomIndex = Random.Range(0, prefabsToSpawn.Length);
                    while(randomIndex == PlayerPrefs.GetInt("lastIndex")){
                        randomIndex = Random.Range(0, prefabsToSpawn.Length);
                    }
                    PlayerPrefs.SetInt("lastIndex", randomIndex);
                }
                
                SpawnedObjects[4] = "breadUp";

                break;
                
            case 4:
                float distance = 0.7f;
                if(Screen.width < 1500){
                    yPos = uiBottomCenter.y - uiBottomCenter.y / 2 + 0.4f;
                }else{
                    yPos = uiBottomCenter.y - uiBottomCenter.y / 2 + 0.9f;
                    distance=0.6f;
                }
                Instantiate(breadDown, new Vector2(parentX, yPos), Quaternion.identity).transform.parent = parentObject.transform;
                
                Instantiate(breadUp, new Vector2(parentX, yPos + distance * (randomNumber + 1) + 0.1f), Quaternion.identity).transform.parent = parentObject.transform;
                for(int i = 1; i < randomNumber + 1; i++ ){
                    instantiatedObject = Instantiate(prefabsToSpawn[randomIndex], new Vector2(parentX, yPos) + new Vector2(0, i * distance), Quaternion.identity);
                    SpawnedObjects[i] = instantiatedObject.tag;
                    instantiatedObject.transform.parent = parentObject.transform;
                    randomIndex = Random.Range(0, prefabsToSpawn.Length);
                    while(randomIndex == PlayerPrefs.GetInt("lastIndex")){
                        randomIndex = Random.Range(0, prefabsToSpawn.Length);
                    }
                    PlayerPrefs.SetInt("lastIndex", randomIndex);
                }
                SpawnedObjects[5] = "breadUp";

                break;

            case 5:
                distance = 0.7f;
                if(Screen.width < 1500){
                    yPos = uiBottomCenter.y - uiBottomCenter.y / 2 ;
                }else{
                    yPos = uiBottomCenter.y - uiBottomCenter.y / 2 + 0.8f;
                    distance = 0.6f;
                }
                Instantiate(breadDown, new Vector2(parentX, yPos), Quaternion.identity).transform.parent = parentObject.transform;
                
                Instantiate(breadUp, new Vector2(parentX, yPos + distance * (randomNumber + 1) + 0.1f), Quaternion.identity).transform.parent = parentObject.transform;
                for(int i = 1; i < randomNumber + 1; i++ ){
                    instantiatedObject = Instantiate(prefabsToSpawn[randomIndex], new Vector2(parentX, yPos) + new Vector2(0, i * distance), Quaternion.identity);
                    SpawnedObjects[i] = instantiatedObject.tag;
                    instantiatedObject.transform.parent = parentObject.transform;
                    randomIndex = Random.Range(0, prefabsToSpawn.Length);
                    while(randomIndex == PlayerPrefs.GetInt("lastIndex")){
                        randomIndex = Random.Range(0, prefabsToSpawn.Length);
                    }
                    PlayerPrefs.SetInt("lastIndex", randomIndex);

                }
                SpawnedObjects[6] = "breadUp";
                break;
        }

    }
}
