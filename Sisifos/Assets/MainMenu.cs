using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;

public class MainMenu : MonoBehaviour
{
   public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }

    public void QuitGame()
    {
        Debug.Log("Quit!!");
        Application.Quit();
    }


    public string UrlOne;
    public string UrlTwo;
    public void OpenLinkOne()
    {
        Application.OpenURL(UrlOne);
        
    }

    public void OpenLinkTwo()
    {
        Application.OpenURL(UrlTwo);
    }
}
