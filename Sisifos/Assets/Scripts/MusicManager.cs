using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    //main cameraya audio source ekle, ses seviyesini kýs 0.4 civarý, main camerayý audio source objesi olarak tanýmla

    //PlayWinMenuSong ve PlayLoseMenuSong için -> ekranlar oyuna baðlandýktan sonra clipleri de baðla!!
    // Camera.main.gameObject.GetComponent<MusicManager>().PlayWinMenuSong(); ontriggeriçine

    [SerializeField] private AudioSource gameMusics;
    [SerializeField] private AudioClip[] _musics;
    [SerializeField] private AudioClip winMenu;
    [SerializeField] private AudioClip loseMenu;


    // [SerializeField] private AudioClip mainMenu, winMenu, loseMenu, levelOne, levelTwo, levelThree, levelFour, levelFive, levelSix;
    //mainMenu, winMenu, loseMenu, levelOne, levelTwo, levelThree, levelFour, levelFive, levelSix;
    // CTRL + Scroll Zoom in & Zoom out




    public void PlaySong()
    {
        gameMusics.Stop();
        gameMusics.clip = _musics[SceneManager.GetActiveScene().buildIndex];
        gameMusics.Play();
    }

    private void Start()
    {
        PlaySong();
    }

    public void PlayWinMenuSong()
    {
        gameMusics.Stop();
        gameMusics.clip = winMenu;
        gameMusics.Play();
    }

    public void PlayLoseMenuSong()
    {
        gameMusics.Stop();
        gameMusics.clip = loseMenu;
        gameMusics.Play();
    }




    //public void PlaySong()
    //{
    //    if(SceneManager.GetActiveScene().buildIndex == 1)
    //    {
    //        gameMusics.clip = _musics[0];
    //        gameMusics.Play(); 
    //    }
    //}

    //static private MusicManager musicManager;


    //protected virtual void Awake()
    //{

    //    if (musicManager == null)
    //    {

    //        musicManager = this;
    //        DontDestroyOnLoad(this);
    //    }
    //    else
    //    {

    //        Destroy(this);
    //        return;
    //    }
    //}

    //protected virtual void Start()
    //{

    //    PlayMainMenuMusic();
    //}


    //static public void PlayMainMenuMusic()
    //{
    //    if (musicManager != null)
    //    {
    //        if (musicManager.gameMusics != null)
    //        {
    //            musicManager.gameMusics.Stop();
    //            musicManager.gameMusics.clip = musicManager.mainMenu;
    //            musicManager.gameMusics.Play();
    //        }
    //    }
    //    else
    //    {
    //        Debug.LogError("check mainMenu component");
    //    }
    //}


    //static public void PlayGameMusic()
    //{
    //    if (musicManager != null)
    //    {
    //        if (musicManager.gameMusics != null)
    //        {
    //            musicManager.gameMusics.Stop();
    //            musicManager.gameMusics.clip = musicManager.levelOne;
    //            musicManager.gameMusics.Play();
    //        }
    //    }
    //    else
    //    {
    //        Debug.LogError("Unavailable MusicPlayer component");
    //    }
    //}
}

