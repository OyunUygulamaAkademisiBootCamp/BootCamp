using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    private PlaneInst _planeInst;
    

    private void Start()
    {
        _planeInst = GameObject.FindObjectOfType<PlaneInst>();
    }

    private void OnBecameInvisible()
    { 
        //bilgisayarda scene sekmesi açıkken çalışmadı. hala visible sanıyor
        _planeInst.RelocatePlane(this.gameObject);
    }
}
     
