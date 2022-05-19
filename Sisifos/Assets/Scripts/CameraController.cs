using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject player;

    private Vector3 offset;

    void Start ()
    {
        //offset = transform.position - player.transform.position;
        offset = new Vector3(0, 0, -0.5f);
    }

    void LateUpdate ()
    {
        transform.position = player.transform.position + offset;
    }
}
