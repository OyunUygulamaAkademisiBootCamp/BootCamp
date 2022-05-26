using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class CollectibleController : MonoBehaviour
{
    public float sizeMultiplier;
    
    public GameObject boulder;

    public float maxSize;
    public float minSize;

    public float weight;
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
    private int currentLevel;
    private float[] collectiblePosXList;
    private GameObject[] createdCollectibles;
    void Start()
    {
        planeWidth = plane.transform.localScale.x;
        planeAngle = plane.transform.rotation.x;
        weight = maxWeight/2;
        _levelController = GameObject.FindObjectOfType<LevelController>();
        currentLevel = _levelController.currentLevel;
        float planeX = plane.transform.position.x;
        collectiblePosXList = new[] {planeX - planeWidth/4f, planeX, planeX + planeWidth/4f};
        Debug.Log("collectible: " + collectiblePosXList[0] +":" +collectiblePosXList[1] +":" +collectiblePosXList[2]);
        SpawnCollectible();
        
        //(planeX - planeWidth/4) , planeX, planeX + planeWidth / 4
    }

    private void Update()
    {
        

    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(weight);
        
        //
        // BOYUT BÜYÜLTENLER
        //
        
        if (other.CompareTag("UpTag"))
        {
            Destroy(other.gameObject);
            UpScale();
            weight += 5;
        }
        
        if (other.CompareTag("CovidTag"))
        {
            Destroy(other.gameObject);
            UpScale();
            weight += 10;
        }
        
        
        //
        // BOYUT KÜÇÜLTENLER
        //
        
        if (other.CompareTag("HealthTag"))
        {
            Destroy(other.gameObject);
            DownScale();
            weight -= 10;
        }
        
        if (other.CompareTag("FamilyTag"))
        {
            Destroy(other.gameObject);
            DownScale();
            weight -= 8;
        }
        
        if (other.CompareTag("MoneyTag"))
        {
            Destroy(other.gameObject);
            DownScale();
            weight -= 7;
        }
        
        if (other.CompareTag("LoveTag"))
        {
            Destroy(other.gameObject);
            DownScale();
            weight -= 6;
        }
        
        if (other.CompareTag("WorkTag"))
        {
            Destroy(other.gameObject);
            DownScale();
            weight -= 5;
        }
        
        
    }

    private void UpScale()
    {
        boulder.transform.localScale = new Vector3(
            boulder.transform.localScale.x + sizeMultiplier, 
            boulder.transform.localScale.y + sizeMultiplier,
            boulder.transform.localScale.z + sizeMultiplier
        );
        
        if (boulder.transform.localScale.x > maxWeight/50)
        {
            //Oyunu durdur (animasyon vs girsin + Game Over)
            Time.timeScale = 0;
        }
        
        Debug.Log("Boyut Büyüdü");
        
        
    }
    
    private void DownScale()
    {
        boulder.transform.localScale = new Vector3(
            boulder.transform.localScale.x - sizeMultiplier, 
            boulder.transform.localScale.y - sizeMultiplier,
            boulder.transform.localScale.z - sizeMultiplier
            );

        if (boulder.transform.localScale.x < maxWeight/800)
        {
            //Oyunu durdur (animasyon girsin + Game Over)
            Time.timeScale = 0;

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
