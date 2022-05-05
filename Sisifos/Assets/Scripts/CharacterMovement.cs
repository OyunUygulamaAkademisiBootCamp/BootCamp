using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    
    public float speed = 10;
    private int line = 1; // 0 = Left, 1 = Middle, 2 = Right
    private float distance = 1.5f;
    
    private Transform tf;
    private Vector3 charPos;
    private Vector3 targetcharPos;
    
    //private float time = 0;
    
    void Start()
    {
        tf = transform;
    }

    void Update()
    {
        MoveForward();
        Debug.Log(line);
        charPos = tf.position;
        if (Input.GetKey(KeyCode.LeftArrow) && line > 0)
        {
            targetcharPos = new Vector3(charPos.x - distance, charPos.y, charPos.z);
            transform.position = Vector3.Lerp(charPos, targetcharPos, 1.0f);
            line--;
            

        }

        if (Input.GetKey(KeyCode.RightArrow) && line < 2 )
        {
            targetcharPos = new Vector3(charPos.x + distance, charPos.y, charPos.z);
            transform.position = Vector3.Lerp(charPos, targetcharPos, 1.0f);
            line++;
            
        }
        
    }

    void MoveForward()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
    

    void lineMovement(bool rightMove)
    {
        // Left
        if (!rightMove)
        {
            line--;
            if (line == -1)
            {
                line = 0;
            }
            Debug.Log("Line: " + line);
        }
        // Right
        else
        {
            line++;
            if (line == 3)
            {
                line = 2;
            }
            Debug.Log("Line: " + line);
        }
        
        // Vector3 targetPos = transform.position.x * Vector3.forward;
        //
        //
        // if (line == 0)
        // {
        //     targetPos += Vector3.left * distance;
        // }
        // else if (line == 2)
        // {
        //     targetPos += Vector3.right * distance;
        // }
        //
    }
}
