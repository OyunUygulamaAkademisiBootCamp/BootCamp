using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class CollectibleController : MonoBehaviour
{
    [SerializeField] private GameObject collectibleObject; // Toplanabilir GameObject tanımlandı.
    [SerializeField] private int collectibleCount;
    private Color[] colors = new []{Color.black, Color.blue, Color.cyan, Color.green, Color.red,Color.magenta, Color.white, Color.blue, Color.cyan, Color.red}; // Toplanabilir GameObject'in renkleri belirlendi.
    public int distanceBtwCollectibles = 5; // Toplanabilir GameObjectlerin instantiate aralığı belirlendi.
    public int distanceToRoad = 10;
    public int planeAngle = -20;
    private float _x, _y, _z, relocateDistanceX,relocateDistanceY,relocateDistanceZ; 
    
    void Start()
    {
        _z = 20.0f;
        relocateDistanceX = collectibleCount % 3;
        relocateDistanceY = -collectibleCount * Convert.ToSingle(distanceBtwCollectibles * Math.Sin(planeAngle * Math.PI / 180));
        relocateDistanceZ = collectibleCount * Convert.ToSingle(distanceBtwCollectibles * Math.Cos(planeAngle * Math.PI / 180));
        float yAngle = Convert.ToSingle(Math.Tan(planeAngle * Math.PI / 180));
        
        for (int i = 1; i <= collectibleCount; i++)
        {
            _z *= i;
            _y = - (_z * yAngle) + distanceToRoad;
            _x = 1.5f* (1- i%3); 
            GameObject createdPlane =  Instantiate(collectibleObject, new Vector3(0,_y,_z),  Quaternion.Euler(new Vector3(0, 0, 0)));
            createdPlane.GetComponent<Renderer>().material.color = colors[i-1];
            
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void relocateCollectible(GameObject _gameObject)
    {
        relocateDistanceX = 1.5f * (1 - ((relocateDistanceX + _gameObject.transform.position.x / 1.5f ) % 3));
        _gameObject.transform.position += new Vector3(relocateDistanceX, relocateDistanceY+distanceToRoad, relocateDistanceZ);
    }
}
