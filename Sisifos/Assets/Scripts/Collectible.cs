using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Toolbars;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    // Start is called before the first frame update
    
    

    void Start()
    
    {
        //_collectibleController = GameObject.FindObjectOfType<CollectibleController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //TODO: object size 
        if(other.CompareTag("Player"))
            gameObject.SetActive(false);
    }


    //ToDo:On became invisible karakter collectible'ın üzerine geldiğinde hata veriyor.
    //private void OnBecameInvisible()
    //{
    //    _collectibleController.relocateCollectible(this.gameObject);
    //}
}