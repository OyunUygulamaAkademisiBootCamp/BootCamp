using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;


// All trigger controls here
public class Player : MonoBehaviour
{
    private CollectibleController _collectibleController;
    private LevelController _levelController;
    private Rigidbody rb;
    private SoundManager sm;
    private bool isDangerZone = false;
    private float boulderWeight;
    

  

   
    
    // Start is called before the first frame update
    void Start()
    {
        _collectibleController  = GameObject.FindObjectOfType<CollectibleController>();
        _levelController  = GameObject.FindObjectOfType<LevelController>();
        rb = gameObject.GetComponent<Rigidbody>();
        sm = gameObject.GetComponent<SoundManager>();

       
        
    }

    // Update is called once per frame

    private void Update()
    {
        boulderWeight = _collectibleController.boulderWeight;
        DangerZone();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Negative"))
        {
            _collectibleController.UpScale(other.gameObject.GetComponent<Rigidbody>().mass);
            sm.CollectNegative();
            other.gameObject.SetActive(false);
            //AnalyticsResult analyticsResult = Analytics.CustomEvent("CollectNegative" + //negativeobjectcounts;
            //Debug.Log("analyticsResults:" + analyticsResult);
                
        } 
        
        if (other.CompareTag("Positive"))
        {
            _collectibleController.DownScale(other.gameObject.GetComponent<Rigidbody>().mass);
            sm.CollectPositive();
            other.gameObject.SetActive(false);
            //AnalyticsResult analyticsResult = Analytics.CustomEvent("CollectPositive" + //positiveobjectcounts;
            //Debug.Log("analyticsResults:" + analyticsResult);

        }

        if (other.CompareTag("Obstacle"))
        {
            Debug.Log("Obstacle");


            if (other.gameObject.GetComponent<Rigidbody>().mass <= rb.mass)
            {
                other.gameObject.SetActive(false);
            }
            else
            {
                _levelController.Failed(Reason.Obstacle);
                

            }
        }
        
        if (other.CompareTag("Hole"))
        {
            if (isDangerZone == true)
            {
                _levelController.Failed(Reason.Hole);
                AnalyticsResult analyticsResult = Analytics.CustomEvent("DiedHole", new Dictionary<string, object>{
                    { "Level", _levelController.GetCurrentLevel() },
                    {"Position", Mathf.RoundToInt(transform.position.x/3f) }
                }
                );
                Debug.Log("analyticsResults:" + analyticsResult);
            }
        }

        if (other.CompareTag("Finish"))
        {
            _levelController.Won();
            sm.FinishLine();
            //AnalyticsResult analyticsResult = Analytics.CustomEvent("LevelWin" + myLevel);
            //Debug.Log("analyticsResults:" + analyticsResult);
        }
    }

    void DangerZone()
    {
        if (boulderWeight >= 20 && boulderWeight <= 80)
        {
            isDangerZone = false;
        }
        else
        {
            isDangerZone = true;
        }
    }
}
