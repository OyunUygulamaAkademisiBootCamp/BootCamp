using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public int currentLevel = 0;
    public GameObject playerObject;
    public GameObject winPanel;
    public GameObject failPanel;
    private CharacterMovement _characterMovement;
    private AsyncOperation sceneAsync;
    private int index;
    private CollectibleController _collectibleController;
    private ObstacleController _obstacleController;
    private AnimationController _animationController;
    private RoadController _roadController;
    private SoundManager sm; 



    void Start()
    {
        index = SceneManager.GetActiveScene().buildIndex;
        _characterMovement = playerObject.GetComponent<CharacterMovement>();
        currentLevel = 0; // index - 1;
        Debug.Log("currentLevel: " + currentLevel);
        _collectibleController = FindObjectOfType<CollectibleController>();
        _animationController = FindObjectOfType<AnimationController>();
        _obstacleController = FindObjectOfType<ObstacleController>();
        _roadController = FindObjectOfType<RoadController>();
        sm = FindObjectOfType<SoundManager>();
    }

    public void Won()
    {
        winPanel.SetActive(true);
        
    }

    public void Failed(Reason reason)
    {
        //Time.timeScale = 0; // OYUNU PAUSE'LUYOR.
        _characterMovement.Stop(); // HEMEN DURMUYOR !!!!  //ş: 

        switch (reason)
        {
            case Reason.Hole:
                Debug.Log("Reason:" + Reason.Hole);
                _animationController.HoleAnimation();
                
                //Time.timeScale = 0;
                break;
            case Reason.Obstacle:
                Debug.Log("Reason:" + Reason.Obstacle);
                //TODO: animasyon eklenecek
                //Time.timeScale = 0;
                break;
            case Reason.Overweight:
                Debug.Log("Reason:" + Reason.Overweight);

                //TODO: animasyon eklenecek
                //Time.timeScale = 0;
                break;
            case Reason.Underweight:
                Debug.Log("Reason:" + Reason.Underweight);
                _animationController.ZeusAnimation();
                //failPanel.SetActive(true);
                //Time.timeScale = 0;
                break;
        }
        failPanel.SetActive(true);
        sm.FailedLevel();
    }
    
    
    public void LoadNextLevel()
    {
        winPanel.SetActive(false);
        SceneManager.UnloadSceneAsync(index);
        SceneManager.LoadScene(index + 1);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(index);        
        winPanel.SetActive(false);

        /*//TODO: relocate everything
         _collectibleController.RelocateCollectible();
        _obstacleController.RelocateObstacles();
        playerObject.transform.position = new Vector3(-0.23f, 1.10f, 1.21f);
*/
    }

    public void ReturnMainMenu()
    {
        SceneManager.LoadScene(0);
        winPanel.SetActive(false);
        SceneManager.UnloadSceneAsync(index);
    }
    
   
    

    
}
