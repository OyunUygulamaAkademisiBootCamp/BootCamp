using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class TouchMove : MonoBehaviour
{
    //Değişkenler
    public float moveSpeed = 300;
    public GameObject character;

    private Rigidbody characterBody;
    private float ScreenWidth;

    private void Start()
    {
        ScreenWidth = Screen.width;
        characterBody = character.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        int i = 0;
        //loop over every touch found
        while (i < Input.touchCount)
        {
            if (Input.GetTouch(i).position.x > ScreenWidth / 2)
            {
                //move right
                RunCharacter(1.0f);
            }

            if (Input.GetTouch(i).position.x < ScreenWidth / 2)
            {
                //move left
                RunCharacter(-1.0f);
            }

            i++;
        }
        
    }
    
    //Test için
    private void FixedUpdate()
    {
        #if UNITY_EDITOR
        RunCharacter(Input.GetAxis("Horizontal"));
        #endif
    }

    public void RunCharacter(float horizontalInput)
    {
        //move player
        characterBody.AddForce(new Vector3(horizontalInput * moveSpeed * Time.deltaTime, 0, 0));
    }
}
