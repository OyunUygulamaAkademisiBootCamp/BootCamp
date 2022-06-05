using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        InitAds();
        AMR.AMRSDK.setOnBannerReady(OnBannerReady);

    }

    public void PlayGame()
    {
        if (PlayerPrefs.GetInt("Tutorial", 0) == 0)
        {
            SceneManager.LoadScene(7); //TODO: change number if new scenes added

        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }
        
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
    
    private void InitAds()
    {
        AMR.AMRSdkConfig config = new AMR.AMRSdkConfig();
        config.ApplicationIdAndroid = "6cc8e89a-b52a-4e9a-bb8c-579f7ec538fe";
        config.BannerIdAndroid = "9fb970db-7d96-4ef2-ac8c-d88ec22270ff";
        config.InterstitialIdAndroid = "92a31414-0b8d-431d-ac43-8d9fc92cbb7e";
        config.RewardedVideoIdAndroid = "e5efb075-59ff-401b-892e-8500ee6f841f";
        AMR.AMRSDK.startWithConfig(config);
        LoadBanner();
        
    }
    
    private void LoadBanner()
    {
        AMR.AMRSDK.loadBanner(AMR.Enums.AMRSDKBannerPosition.BannerPositionBottom, false);
        
    }
    
    private void LoadInterstitial()
    {
        AMR.AMRSDK.loadInterstitial();
    }

    private void OnBannerReady(string networkName, double ecpm)
    {
        LoadInterstitial();
    }
}
