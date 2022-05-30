using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class CollectibleController : MonoBehaviour
{
    public float sizeMultiplier;
    
    public GameObject boulder;
    

    public float boulderWeight;
    public float maxWeight = 100.0f;

    public GameObject[] collectibleObjects;
    public int[] collectibleGaps;
    public int[] gapRanges;
    
    public int[] collectibleKindNumbers;
    public int[] collectibleCounts;
    public GameObject plane;

    private float planeWidth;
    private float planeAngle;
    private LevelController _levelController;
    private CharacterMovement _characterMovement;
    private int currentLevel;
    private float[] collectiblePosXList;
    private GameObject[] createdCollectibles;

    private int speed;
    
    
    void Start()
    {
        planeWidth = plane.transform.localScale.x;
        planeAngle = plane.transform.rotation.x;
        boulderWeight = maxWeight/2;
        _levelController = GameObject.FindObjectOfType<LevelController>();
        _characterMovement = GameObject.FindObjectOfType<CharacterMovement>();
        currentLevel = _levelController.currentLevel;
        float planeX = plane.transform.position.x;
        collectiblePosXList = new[] {planeX - planeWidth/4f, planeX, planeX + planeWidth/4f};
        SpawnCollectible();
        
        //(planeX - planeWidth/4) , planeX, planeX + planeWidth / 4
    }

    private void Update()
    {
       


    }
    

    public void UpScale(float weight)
    {
        if (boulder.transform.localScale.x <= 2)
        {
            boulder.transform.localScale = new Vector3(
                boulder.transform.localScale.x + sizeMultiplier,
                boulder.transform.localScale.y + sizeMultiplier,
                boulder.transform.localScale.z + sizeMultiplier
            );
        }

        boulderWeight += weight; 
        _characterMovement.SpeedDown(Convert.ToSingle(Math.Round(70/weight,1))); //TODO: optimize
        Debug.Log("Weight: " + boulderWeight);

        

        
        if (boulderWeight >= maxWeight)
        {
            //Oyunu durdur (animasyon vs girsin + Game Over)
            _levelController.Failed(Reason.Overweight);
        }
        
        Debug.Log("Boyut Büyüdü");

        
    }
    
    public void DownScale(float weight)
    {
        if (boulder.transform.localScale.x >= 0.3f)
        {
            boulder.transform.localScale = new Vector3(
                boulder.transform.localScale.x - sizeMultiplier,
                boulder.transform.localScale.y - sizeMultiplier,
                boulder.transform.localScale.z - sizeMultiplier
            );
        }

        boulderWeight -= weight; 
        _characterMovement.SpeedUp(Convert.ToSingle(Math.Round(70/weight,1))); //TODO: optimize
        Debug.Log("Weight: " + boulderWeight);


        if (boulderWeight <= 0)
        {
            _levelController.Failed(Reason.Underweight);

        }
        Debug.Log("Boyut Küçüldü");

        
    }

    void RelocateCollectible()
    {
        
    }

    void SpawnCollectible()
    {
        float yAngle = Convert.ToSingle(Math.Tan(30 * Math.PI / 180)); //tODO : plane angle
        float _z = 10;
        int gap = collectibleGaps[currentLevel];
        int gapRange = gapRanges[currentLevel];
        for (int i = 0; i < collectibleCounts[currentLevel]; i++)
        {
            int rand = new Random().Next(0, collectibleKindNumbers[currentLevel]);
            GameObject collectibleOb = collectibleObjects[rand];
            int xRand = new Random().Next(0, 3);
            float _x = collectiblePosXList[xRand];
            Debug.Log("xRand: " + xRand + " _x: " + _x);
            _z = _z + new Random().Next( gap - gapRange, gap + gapRange+1);
            float _y = yAngle * _z + 0.3f;
            Debug.Log(_x + " : " + _y + " : " + _z);
            GameObject collectibleObject  =  Instantiate(collectibleOb, new Vector3(_x,_y,_z),  Quaternion.Euler(new Vector3(0, 0, 0)));
            
        } 
        
    }
}
