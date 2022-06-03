using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

public class ObstacleController : MonoBehaviour
{
    public float maxWeight = 100.0f;

    public GameObject[] obstacleObjects;
    public int[] obstacleGaps;
    public int[] gapRanges;
    
    public int[] obstacleKindNumbers;
    public int[] obstacleCounts;
    public GameObject plane;

    private float planeWidth;
    private float planeAngle;
    private LevelController _levelController;
    private CharacterMovement _characterMovement;
    private int currentLevel;
    private float[] obstaclePosXList;
    private List<GameObject> createdObstacles;

    private int speed;
    // Start is called before the first frame update
    void Start()
    {
        planeWidth = plane.transform.localScale.x;
        planeAngle = plane.transform.rotation.x;
        _levelController = GameObject.FindObjectOfType<LevelController>();
        _characterMovement = GameObject.FindObjectOfType<CharacterMovement>();
        currentLevel = _levelController.currentLevel;
        float planeX = plane.transform.position.x;
        obstaclePosXList = new[] {planeX - planeWidth/4f, planeX, planeX + planeWidth/4f};
        createdObstacles =  new List<GameObject>();
        SpawnObstacle();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RelocateObstacles()
    {
        float yAngle = Convert.ToSingle(Math.Tan(30 * Math.PI / 180)); //tODO : plane angle
        float _z = 10;
        int gap = obstacleGaps[currentLevel];
        int gapRange = gapRanges[currentLevel];
        for (int i = 0; i < obstacleObjects.Length ; i++)
        {
            int xRand = new Random().Next(0, 3);
            float _x = obstaclePosXList[xRand];
            //Debug.Log("xRand: " + xRand + " _x: " + _x);
            _z = _z + new Random().Next( gap - gapRange, gap + gapRange+1);
            float _y = yAngle * _z + 0.2f;
            GameObject gameOb = obstacleObjects[i];
            gameOb.transform.position = new Vector3(_x, _y, _z);
            gameOb.SetActive(true);
        }
        
    }
    
    void SpawnObstacle()
    {
        float yAngle = Convert.ToSingle(Math.Tan(30 * Math.PI / 180)); //tODO : plane angle
        float _z = 10;
        int gap = obstacleGaps[currentLevel];
        int gapRange = gapRanges[currentLevel];
        Debug.Log("obstacleCount: " +  obstacleCounts[currentLevel]);
        for (int i = 0; i < obstacleCounts[currentLevel]; i++)
        {
            int rand = new Random().Next(0, obstacleKindNumbers[currentLevel]);
            GameObject obstacleOb = obstacleObjects[rand];
            int xRand = new Random().Next(0, 3);
            float _x = obstaclePosXList[xRand];
            //Debug.Log("xRand: " + xRand + " _x: " + _x);
            _z = _z + new Random().Next( gap - gapRange, gap + gapRange+1);
            float _y = yAngle * _z + 0.2f;
            //Debug.Log(_x + " : " + _y + " : " + _z);
            if (obstacleOb.CompareTag("Hole"))
            {
                GameObject obstacleObject  =  Instantiate(obstacleOb, new Vector3(_x,_y,_z),  Quaternion.identity);
                createdObstacles.Add(obstacleObject);
            }
            else
            {
                GameObject obstacleObject  =  Instantiate(obstacleOb, new Vector3(_x,_y,_z),  Quaternion.identity);
                createdObstacles.Add(obstacleOb);

            }
            
        } 
        
    }
}
