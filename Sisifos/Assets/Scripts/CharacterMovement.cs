using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.PlayerLoop;
using UnityEngine.TextCore.Text;
using UnityEngine.UIElements;

public class CharacterMovement : MonoBehaviour
{
    public bool isGround;
    public float forwardSpeed = 20; // Hız değişkeni
    
    public Rigidbody rb; // Rigidbody değişkeni
    private Transform tf; // Transform değişkeni
    
    private Animator anim;
    private float updatedSpeed;
    public float horizontalSpeed = 1000;
    private float ScreenWidth;
    private int speedMultiplier = 4;
    private CollectibleController _collectible;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        anim = GetComponentInChildren<Animator>();
        
        ScreenWidth = Screen.width;

        updatedSpeed = forwardSpeed;


    }

    private void Update()
    {
        //transform.Translate(Vector3.forward * forwardSpeed);
            
            rb.velocity = new Vector3(0, 0, forwardSpeed);
            if (updatedSpeed == 0)
            {
                forwardSpeed--;
                if (forwardSpeed < 0)
                    forwardSpeed = 0;
            }
            if (updatedSpeed > forwardSpeed)
            {
                forwardSpeed+=0.1f;
            }else if (updatedSpeed < forwardSpeed)
            {
                forwardSpeed-=0.1f;
            } 

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

    public void RunCharacter(float horizontalInput)
    {
        //horizontal move player
        
        rb.AddForce(new Vector3(horizontalInput * horizontalSpeed * Time.deltaTime, 0, 0));
    }

    public void SpeedChanged(int speed)
    {
        updatedSpeed =  speedMultiplier * speed;
    }

    

    public void Stop()
    {
        updatedSpeed = 0;
        gameObject.transform.GetChild(0).GetComponent<Animator>().speed=0;
        gameObject.transform.GetChild(1).GetComponent<Animator>().speed=0;
    }
}
