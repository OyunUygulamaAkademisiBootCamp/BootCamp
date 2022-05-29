using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CollectibleController _collectibleController;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        _collectibleController  = GameObject.FindObjectOfType<CollectibleController>();
        rb = gameObject.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger enter player");
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
                Time.timeScale = 0;

            }
        }
        
        if (other.CompareTag("Hole"))
        {
            Time.timeScale = 0;
        }
    }
}
