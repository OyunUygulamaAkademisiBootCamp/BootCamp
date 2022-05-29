using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public int currentLevel = 0;
    public int[] roadLengths;
    public int[] collectibleCounts;
    public bool inGame;
    public GameObject[] environmentObjects;
    public GameObject playerObject;
    public GameObject underweightObj;
    private int _roadLength;
    private int _collectibleCount;
    private CharacterMovement _characterMovement;

    void Start()
    {
        _characterMovement = playerObject.GetComponent<CharacterMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        //TODO
    }

    public void Won()
    {
        currentLevel++;
    }

    public void Failed(Reason reason)
    {
        if (reason.Equals(Reason.Underweight))
        {
            underweightObj.GetComponent<Animation>().Play();
        }
        
        _characterMovement.Stop();
    }

    void Play()
    {
        
    }

    
}
