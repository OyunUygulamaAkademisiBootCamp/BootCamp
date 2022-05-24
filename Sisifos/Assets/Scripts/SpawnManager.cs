using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnManager : MonoBehaviour
{
    public GameObject spawner;
    public Transform player;
    private Vector3 pos1;
    private Vector3 pos2;
    private Vector3 pos3;
    void Start()
    {
        Vector3 pos1 = new Vector3(spawner.transform.position.x, spawner.transform.position.y, spawner.transform.position.z);
        Vector3 pos2 = new Vector3(spawner.transform.position.x + 0.75f, spawner.transform.position.y, spawner.transform.position.z);
        Vector3 pos3 = new Vector3(spawner.transform.position.x + 1.5f, spawner.transform.position.y, spawner.transform.position.z);
        SpawnSpawner();

    }

    // Update is called once per frame
    void Update()
    {
    }

    private void SpawnSpawner()
    {
        Instantiate(spawner, pos1, Quaternion.identity);
        Instantiate(spawner, pos2, Quaternion.identity);
        Instantiate(spawner, pos3, Quaternion.identity);

    }
}
