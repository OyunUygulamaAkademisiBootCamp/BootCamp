using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UIElements;

public class CharacterMovement : MonoBehaviour
{

    public float speed = 10; // Hız değişkeni
    private int line = 1; // 0 = Left, 1 = Middle, 2 = Right
    private float distance = 1.5f; // Mesafe değişkeni (Şuan kullanılmıyor)
    
    private Rigidbody _rigidbody; // Rigidbody değişkeni
    private Transform tf; // Transform değişkeni
    
    private Vector3 charPos; 
    private Vector3 targetcharPos; 
    
    [SerializeField] private Transform plane;

    private Vector2 startPos, endPos;
    

    public int pixelThreshold = 10;
    //private float time = 0;

    void Start()
    {
        tf = transform;
        if (plane != null)
        {
            distance = (plane.localScale.z / 3) * 10;
        }

        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        MoveForward(); // constant force ile yapabiliriz
        charPos = tf.position;

        //checkScreenInput(); //ToDo: ekrandan swipe'ı anlamamız gerekiyor
       if (Input.GetKeyDown(KeyCode.LeftArrow) && line > 0)
        {
            Debug.Log(line);
            //targetcharPos = new Vector3(charPos.x - distance, charPos.y, charPos.z);
            //transform.position = Vector3.Lerp(charPos, targetcharPos, 1.0f);
            line--;
            
            //force deneme
            _rigidbody.AddForce(Vector3.left * 200);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && line < 2)
        {
            Debug.Log(line);
            //targetcharPos = new Vector3(charPos.x + distance, charPos.y, charPos.z);
            //transform.position = targetcharPos; //Vector3.Lerp(charPos, targetcharPos, 1.0f);
            line++;
            
            _rigidbody.AddForce(Vector3.right * 200);
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

    }

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
                line++;
                _rigidbody.AddForce(Vector3.right * 200);
                Debug.Log("Right");
                
            }else if (endPos.x <= (startPos.x - pixelThreshold) && line>0)
            {
                //Left
                line--;
                _rigidbody.AddForce(Vector3.left * 200);
                Debug.Log("Left");
            }
        }
    }
}
