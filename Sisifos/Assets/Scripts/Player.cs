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

    // Start is called before the first frame update
    void Start()
    {
        _collectibleController  = GameObject.FindObjectOfType<CollectibleController>();
        _levelController  = GameObject.FindObjectOfType<LevelController>();
        rb = gameObject.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player Trigger: " + other.tag);
        if (other.CompareTag("Positive"))
        {
            _collectibleController.UpScale(other.gameObject.GetComponent<Rigidbody>().mass);
            other.gameObject.SetActive(false);
                
        } 
        
        if (other.CompareTag("Negative"))
        {
            _collectibleController.DownScale(other.gameObject.GetComponent<Rigidbody>().mass);
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
            _levelController.Failed(Reason.Hole);
        }

        if (other.CompareTag("Finish"))
        {
            _levelController.Won();
        }
    }
}
