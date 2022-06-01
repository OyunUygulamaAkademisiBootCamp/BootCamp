using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPointParticle : MonoBehaviour
{

    private LevelController _levelController;
    public GameObject winPanel;

    private void Start()
    {
        _levelController = FindObjectOfType<LevelController>();
    }

    private void OnTriggerEnter(Collider othercolInfo)
    {
        if (othercolInfo.tag == "Player")
        {
            winPanel.SetActive(true);
            _levelController.Won();
            
        }
        
       //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public void LoadNextLevel()
    {
        winPanel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void RestartLevel()
    {
        winPanel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReturnMainMenu()
    {
        winPanel.SetActive(false);
        SceneManager.LoadScene("MainMenu");
    }
}
