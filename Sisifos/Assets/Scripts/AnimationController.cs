using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SoundManager))]
public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator zuusAnim;
    [SerializeField] private GameObject zuus;


    public Camera mainCam;
    public Camera sideCam;

    public GameObject losePanel;

    public Animator animator_blink;
    private SoundManager sm;
    

    
    
    private void Start()
    {
        zuus.SetActive(false);
        //Camera.SetupCurrent(mainCam);
        mainCam.gameObject.SetActive(true);
        sideCam.gameObject.SetActive(false);
        sm = gameObject.GetComponent<SoundManager>();
    }

    

    void FadetoNewCameraPos()
    {
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
        losePanel.SetActive(true);
        sm.BrokenBones();


    }
    

    public void HoleAnimation()
    {
        FadetoNewCameraPos();
        StartCoroutine(ChangeCameraPos());

    }
    public void ZeusAnimation()
    {
        zuus.SetActive(true);
        zuusAnim.Play("ZeusStrike");
        
    }
}
