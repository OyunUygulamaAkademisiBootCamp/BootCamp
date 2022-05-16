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
    private Vector3 direction;
    private ConstantForce _constantForce;

    public float forwardSpeed = 100; // Hız değişkeni
    private int line = 1; // 0 = Left, 1 = Middle, 2 = Right
    
    
    private Rigidbody _rigidbody; // Rigidbody değişkeni
    private Transform tf; // Transform değişkeni
    
    private Vector3 charPos; 
    private Vector3 targetcharPos; 
    
    [SerializeField] private Transform plane;

    private Vector2 startPos, endPos;
    
    private Animator anim;

    public int pixelThreshold = 10;
    //private float time = 0;

    private float trplayerX;

    void Start()
    {
        // tf = transform;
        // if (plane != null)
        // {
        //     distance = (plane.localScale.z / 3) * 10;
        // }
        _rigidbody = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();

    }

    private void Update()
    {
        anim.SetBool("isRolling",true);
        
        
    }

    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * forwardSpeed);




        //charPos = tf.position;


        //checkScreenInput(); //ToDo: ekrandan swipe'ı anlamamız gerekiyor
        // if (Input.GetKeyDown(KeyCode.LeftArrow) && line > 0)
        //  {
        //      Debug.Log(line);
        //      //targetcharPos = new Vector3(charPos.x - distance, charPos.y, charPos.z);
        //      //transform.position = Vector3.Lerp(charPos, targetcharPos, 1.0f);
        //      line--;
        //      
        //      //force deneme
        //      _rigidbody.AddForce(Vector3.left * 200);
        //  }
        //
        //  if (Input.GetKeyDown(KeyCode.RightArrow) && line < 2)
        //  {
        //      Debug.Log(line);
        //      //targetcharPos = new Vector3(charPos.x + distance, charPos.y, charPos.z);
        //      //transform.position = targetcharPos; //Vector3.Lerp(charPos, targetcharPos, 1.0f);
        //      line++;
        //      
        //      _rigidbody.AddForce(Vector3.right * 200);
        //  }

    }
    


    // void lineMovement(bool rightMove)
    // {
    //     // Left
    //     if (!rightMove)
    //     {
    //         line--;
    //         if (line == -1)
    //         {
    //             line = 0;
    //         }
    //
    //         Debug.Log("Line: " + line);
    //     }
    //     // Right
    //     else
    //     {
    //         line++;
    //         if (line == 3)
    //         {
    //             line = 2;
    //         }
    //
    //         Debug.Log("Line: " + line);
    //     }
    //
    // }
    

    private void checkScreenInput()
    {
        //https://www.youtube.com/watch?v=Fh8vfm1sAk4
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Debug.Log("startPos set");
            startPos = Input.GetTouch(0).position;
            
        }else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            Debug.Log("endPos set");

            endPos = Input.GetTouch(0).position;
            if (endPos.x >= (startPos.x + pixelThreshold) && line<2)
            {
                //Right
                _rigidbody.AddForce(Vector3.right * 200);
                Debug.Log("Right");
                
            }else if (endPos.x <= (startPos.x - pixelThreshold) && line>0)
            {
                //Left
                _rigidbody.AddForce(Vector3.left * 200);
                Debug.Log("Left");
            }
        }
    }
}
