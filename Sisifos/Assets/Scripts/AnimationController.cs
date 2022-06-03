using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator zuusAnim;
    [SerializeField] private GameObject zuus;


    public Camera mainCam;
    public Camera sideCam;

    public GameObject losePanel;

    public Animator animator_blink;

    public SoundManager sm;

    

    public void FadetoNewCameraPos()
    {
        animator_blink.SetTrigger("Blink");
    }

    public void OnFadeComplete()
    {

    }

    IEnumerator ChangeCameraPos()
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
    
  
    private void Start()
    {
        zuus.SetActive(false);
        //Camera.SetupCurrent(mainCam);
        mainCam.gameObject.SetActive(true);
        sideCam.gameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        //kýrmýzý taraftayken hole için
        if (other.CompareTag("Hole"))
        {
            zuus.SetActive(true);
            zuusAnim.Play("ZeusStrike");
            Debug.Log("düseyrumm");
            Destroy(other.gameObject);
        }

        //mavi taraftayken hole için
        if (other.CompareTag("Hole"))
        {
            FadetoNewCameraPos();
            //Camera.SetupCurrent(sideCam);
            mainCam.gameObject.SetActive(false);
            sideCam.gameObject.SetActive(true);
            StartCoroutine(ChangeCameraPos());
           

        }
    }
}
