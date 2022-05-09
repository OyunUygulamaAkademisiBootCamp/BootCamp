using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    private RoadController _roadController;
    

    private void Start()
    {
        _roadController = GameObject.FindObjectOfType<RoadController>();
    }

    private void OnBecameInvisible()
    { 
        //bilgisayarda scene sekmesi açıkken çalışmadı. hala visible sanıyor
        _roadController.RelocatePlane(this.gameObject);
    }
}
     
