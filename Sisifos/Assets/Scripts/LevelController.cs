using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public int currentLevel = 0;
    public int[] roadLengths;
    public int[] collectibleCounts;
    public bool inGame;
    public GameObject[] environmentObjects;
    public GameObject playerObject; 
    private int _roadLength;
    private int _collectibleCount;
    
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //TODO
    }

    void Won()
    {
        currentLevel++;
    }

    void Failed()
    {
        
    }

    void Play()
    {
        
    }
}
