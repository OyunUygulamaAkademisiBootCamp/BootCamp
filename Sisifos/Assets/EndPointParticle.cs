using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPointParticle : MonoBehaviour
{

    public GameObject winPanel;
    private void OnTriggerEnter(Collider othercolInfo)
    {
        if (othercolInfo.tag == "Player")
        {
            winPanel.SetActive(true);
        }

      
       //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReturnMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
