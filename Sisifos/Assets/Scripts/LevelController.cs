using System;
using System.Linq.Expressions;
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
    private SoundManager sm;
    private MusicManager mm;
    private float timeLeft;
    private bool isAnimPlay;
    
    void Start()
    {
        index = SceneManager.GetActiveScene().buildIndex;
        _characterMovement = playerObject.GetComponent<CharacterMovement>();
        //currentLevel = 0; // index - 1;
        Debug.Log("currentLevel: " + currentLevel);
        _collectibleController = FindObjectOfType<CollectibleController>();
        _animationController = FindObjectOfType<AnimationController>();
        _obstacleController = FindObjectOfType<ObstacleController>();
        sm = FindObjectOfType<SoundManager>();
        mm = FindObjectOfType<MusicManager>();
        ShowBanner();
    }

    private void Update()
    {
        if (isAnimPlay)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                OpenFailScreen();
            }
        }

        
    }

    public void Won()
    {
        winPanel.SetActive(true);
        mm.PlayWinMenuSong();
    }

    public void Failed(Reason reason)
    {
        
        isAnimPlay = true;
        //Time.timeScale = 0; // OYUNU PAUSE'LUYOR.
        _characterMovement.Stop();// HEMEN DURMUYOR !!!!  //ş: 

        switch (reason)
        {
            case Reason.Hole:
                Debug.Log("Reason:" + Reason.Hole);
                timeLeft = 2f;
                _animationController.HoleAnimation();
                break;
            case Reason.Obstacle:
                Debug.Log("Reason:" + Reason.Obstacle);
                _animationController.ZeusAnimation();
                timeLeft = 1f;
                break;
            case Reason.Overweight:
                Debug.Log("Reason:" + Reason.Overweight);
                _animationController.HoleAnimation();
                timeLeft = 2f;
                break;
            case Reason.Underweight:
                Debug.Log("Reason:" + Reason.Underweight);
                _animationController.ZeusAnimation();
                timeLeft = 2.3f;
                break;
        }

       
        
    }

    private void OpenFailScreen()
    {
        isAnimPlay = false;
        failPanel.SetActive(true);
        sm.FailedLevel();
       
    }
    
    public void LoadNextLevel()
    {
        failPanel.SetActive(false);
        winPanel.SetActive(false);
        if (index == 7)
        {
            Debug.Log("index sıfırlandı");
            index = 0;
            SceneManager.LoadScene(index + 1);
            SceneManager.UnloadSceneAsync(7);
        }else if (index == 6)
        {
            //TODO:Levels ended
        } 
        else
        {
            SceneManager.LoadScene(index + 1);
            SceneManager.UnloadSceneAsync(index);
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(index);
        winPanel.SetActive(false);
        failPanel.SetActive(false);

    }

    public void ReturnMainMenu()
    {
        SceneManager.LoadScene(0);
        winPanel.SetActive(false);
        failPanel.SetActive(false);
        SceneManager.UnloadSceneAsync(index);
    }
    
   
    public int GetCurrentLevel()
    {
        return currentLevel;
    }

   

    private void ShowBanner()
    {
        AMR.AMRSDK.showBanner();
    }
    
}
