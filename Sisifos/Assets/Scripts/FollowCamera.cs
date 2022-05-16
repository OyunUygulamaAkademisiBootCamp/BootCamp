using System;
using Cinemachine;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform player;

    public float smoothSpeed = 0.125f;

    private void Update()
    {
        transform.position = player.position;
    }
}
