using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public int currentLevel = 0;
    public int[] roadLengths;
    public int[] collectibleCounts;
    public bool inGame;
    public GameObject[] environmentObjects;
    public GameObject playerObject;
    public GameObject underweightObj;
    private int _roadLength;
    private int _collectibleCount;
    private CharacterMovement _characterMovement;
    private AsyncOperation sceneAsync;


    void Start()
    {
        _characterMovement = playerObject.GetComponent<CharacterMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        //TODO
    }

    public void Won()
    {
        currentLevel++;
    }

    public void Failed(Reason reason)
    {
        //Time.timeScale = 0; // OYUNU PAUSE'LUYOR.
        _characterMovement.Stop(); // HEMEN DURMUYOR !!!!

        if (reason.Equals(Reason.Underweight))
        {
            underweightObj.GetComponent<Animation>().Play();
        }else if (reason.Equals(reason == Reason.Overweight))
        {
            
        }else if (reason.Equals(reason == Reason.Hole))
        {
            
        }else if (reason.Equals(reason == Reason.Obstacle))
        {

        }
        
    }

    public void Play(bool newLevel)
    {
        if (newLevel)
        {
            StartCoroutine(loadScene(currentLevel));

        }
        else
        {
         //TODO:relocate gaps obstacles and collectibles   
        }
        
    }
    //https://stackoverflow.com/questions/45798666/move-transfer-gameobject-to-another-scene
    IEnumerator loadScene(int index)
    {
        Debug.Log("index:" + index);
        AsyncOperation scene = SceneManager.LoadSceneAsync(index, LoadSceneMode.Additive);
        scene.allowSceneActivation = false;
        sceneAsync = scene;

        //Wait until we are done loading the scene
        while (scene.progress < 0.9f)
        {
            Debug.Log("Loading scene " + " [][] Progress: " + scene.progress);
            yield return null;
        }
        OnFinishedLoadingAllScene();
    }
    
    void enableScene(int index)
    {
        //Activate the Scene
        sceneAsync.allowSceneActivation = true;


        Scene sceneToLoad = SceneManager.GetSceneByBuildIndex(index);
        if (sceneToLoad.IsValid())
        {
            Debug.Log("Scene is Valid");
            SceneManager.MoveGameObjectToScene(gameObject, sceneToLoad);
            SceneManager.SetActiveScene(sceneToLoad);
        }
    }

    void OnFinishedLoadingAllScene()
    {
        Debug.Log("Done Loading Scene");
        enableScene(currentLevel);
        SceneManager.UnloadSceneAsync(currentLevel - 1);
        Debug.Log("Scene Activated!");
    }
    

    
}
