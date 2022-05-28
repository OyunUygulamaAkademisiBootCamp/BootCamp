using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Toolbars;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    private CollectibleController _collectibleController;
    

    void Start()
    
    {
        //_collectibleController = GameObject.FindObjectOfType<CollectibleController>();
        _collectibleController = GameObject.FindObjectOfType<CollectibleController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //TODO: object size 
        if (other.CompareTag("Player"))
        {

            if (gameObject.CompareTag("Positive"))
            {
                _collectibleController.UpScale(gameObject.GetComponent<Rigidbody>().mass);
                
            }else if (gameObject.CompareTag("Negative"))
            {
                _collectibleController.DownScale(gameObject.GetComponent<Rigidbody>().mass);
            }
            gameObject.SetActive(false);
        }
    }

}