using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Toolbars;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    // Start is called before the first frame update
    private  CollectibleController _collectibleController;
    

    void Start()
    
    {
        //_collectibleController = GameObject.FindObjectOfType<CollectibleController>();
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.localScale = new Vector3(other.transform.localScale.x+0.1f, other.transform.localScale.y+0.1f,
                other.transform.localScale.z+0.1f);
            Debug.Log("Collectible Toplandı!");
            Destroy(gameObject);
        }
    }
    
    
    //ToDo:On became invisible karakter collectible'ın üzerine geldiğinde hata veriyor.
    //private void OnBecameInvisible()
    //{
    //    _collectibleController.relocateCollectible(this.gameObject);
    //}
}