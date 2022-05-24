using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> objectsToSpawn = new List<GameObject>();
    private float currentTimeToSpawn;
    public bool isRandomize = true;
    private Vector3 pos = new Vector3();
    private int index;

    void Start()
    {
        pos = transform.position;
        InvokeRepeating("SpawnObject",1,3);

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SpawnObject()
    {
        index = Random.Range(0, objectsToSpawn.Count);

        if (objectsToSpawn.Count > 0)
        {
            Instantiate(objectsToSpawn[index], pos, Quaternion.identity);
            pos.y = pos.y * 1.25f + 0.5f;
            pos.z = pos.z * 1.25f;

        }
        
    }
    
}
