using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SoundManager))]
public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator zuusAnim;
    [SerializeField] private GameObject zuus;
    [SerializeField] private GameObject blinkAnimPrefab;


    public Camera mainCam;
    public Camera sideCam;

    public GameObject losePanel;

    public Animator animator_blink;
    private SoundManager sm;
    private MusicManager mm;
    private int failCounter;
    

    
    
    private void Start()
    {
        zuus.SetActive(false);
        mainCam.gameObject.SetActive(true);
        sideCam.gameObject.SetActive(false);
        sm = gameObject.GetComponent<SoundManager>();
        mm = gameObject.GetComponent<MusicManager>();
        AMR.AMRSDK.setOnInterstitialDismiss(OnInterstitialDismiss);

        StartCoroutine(_waiter());

    }

    IEnumerator _waiter()
    {
      
        yield return new WaitForSeconds(2);
    }

    

    void FadetoNewCameraPos()
    {
        blinkAnimPrefab.SetActive(true);
        animator_blink.SetTrigger("Blink");
        mainCam.gameObject.SetActive(false);
        sideCam.gameObject.SetActive(true);
    }

    public void OnFadeComplete()
    {

    }

    public IEnumerator ChangeCameraPos()
    {
        sm.SisifosScream();
        var _cameraPos = sideCam.gameObject.transform.position;
        int counter = 0;
        while (counter < 20) // 4 saniye
        {
            sideCam.gameObject.transform.Translate(new Vector3(0, 0, -0.5f));
            _cameraPos = sideCam.gameObject.transform.position;
            counter++;
            yield return new WaitForSeconds(0.1f);
        }
        
        mainCam.gameObject.SetActive(true);
        sideCam.gameObject.SetActive(false);
        
        sm.BrokenBones();
        //TODO: ShowInterstitial();

    }
    

    public void HoleAnimation()
    {
        failCounter++;
        FadetoNewCameraPos();
        StartCoroutine(ChangeCameraPos());

    }
    public void ZeusAnimation()
    {
        failCounter++;
        zuus.SetActive(true);
        zuusAnim.Play("ZeusStrike");
        _waiter();
        sm.PlayZeusStrike();
        
        //yield return new  WaitForSeconds(0.3f);
        //TODO: ShowInterstitial();


    }

    private void LoseScreen()
    {
        losePanel.SetActive(true);
        mm.PlayLoseMenuSong();

    }

    private void ShowInterstitial()
    {
        Time.timeScale = 0;
        if (failCounter % 3 == 1)
        {
            if (AMR.AMRSDK.isInterstitialReady())
                AMR.AMRSDK.showInterstitial();
            else
                LoseScreen();
        }else
            LoseScreen();
        
        
    }

    public void OnInterstitialDismiss()
    {
        LoseScreen();
        Time.timeScale = 1;
        AMR.AMRSDK.loadInterstitial();
    }

}
