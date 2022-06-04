using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;


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
            
                
        } 
        
        if (other.CompareTag("Positive"))
        {
            _collectibleController.DownScale(other.gameObject.GetComponent<Rigidbody>().mass);
            sm.CollectPositive();
            other.gameObject.SetActive(false);

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
            }
        }

        if (other.CompareTag("Finish"))
        {
            _levelController.Won();
            sm.FinishLine();
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
