using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject player, zeus;
    

    public Vector3 offset, zeusOffset;

    void Start ()
    {
        //offset = transform.position - player.transform.position;
        
    }

    void LateUpdate ()
    {
        zeus.transform.position = player.transform.position + zeusOffset;
        transform.position = player.transform.position + offset;
    }
}
