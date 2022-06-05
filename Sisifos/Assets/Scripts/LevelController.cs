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

    public void Won()
    {
        winPanel.SetActive(true);
        mm.PlayWinMenuSong();
        
        
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
                break;
            case Reason.Obstacle:
                Debug.Log("Reason:" + Reason.Obstacle);
               
                _animationController.ZeusAnimation();

                
                break;
            case Reason.Overweight:
                Debug.Log("Reason:" + Reason.Overweight);
                _animationController.HoleAnimation();
                break;
            case Reason.Underweight:
                Debug.Log("Reason:" + Reason.Underweight);
                _animationController.ZeusAnimation();
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
    
   
    public int GetCurrentLevel()
    {
        return currentLevel;
    }

   

    private void ShowBanner()
    {
        AMR.AMRSDK.showBanner();
    }
    
    

}
