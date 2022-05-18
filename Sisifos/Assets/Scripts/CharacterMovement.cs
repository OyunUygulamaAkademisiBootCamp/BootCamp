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

    public float forwardSpeed; // Hız değişkeni
    private int line = 1; // 0 = Left, 1 = Middle, 2 = Right

    private float timer = 0.0f;
    
    private Rigidbody _rigidbody; // Rigidbody değişkeni
    private Transform tf; // Transform değişkeni
    
    private Vector3 charPos; 
    private Vector3 targetcharPos; 
    
    [SerializeField] private Transform plane;

    private Vector2 startPos, endPos;
    
    private Animator anim;

    private Boolean anyCol;

    public int pixelThreshold = 10;
    //private float time = 0;

    private float trplayerX;

    void Start()
    {
        
        forwardSpeed = 0.01f;
        transform.position = new Vector3(0, 0.1446f, 0.1371f);
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
        


    }

    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * forwardSpeed);
        
        //timer += Time.deltaTime;
        //Debug.Log(timer);
        //if (timer > 5)
        //{
        //    Debug.Log("TRANSLATE!");
        //}

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            forwardSpeed = 0.03f;
        }
    }
}
