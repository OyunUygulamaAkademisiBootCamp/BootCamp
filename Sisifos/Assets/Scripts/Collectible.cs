using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    // Start is called before the first frame update
    private  CollectibleController _collectibleController;
    

    void Start()
    
    {
        _collectibleController = GameObject.FindObjectOfType<CollectibleController>();
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _collectibleController.relocateCollectible(this.gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        _collectibleController.relocateCollectible(this.gameObject);
    }
}