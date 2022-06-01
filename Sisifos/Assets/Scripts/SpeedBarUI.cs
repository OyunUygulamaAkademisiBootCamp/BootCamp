using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedBarUI : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] GameObject[] _speedUI;
  



    void Start()
    {
        speed = 14f;
       
    }

    // Update is called once per frame
    void Update()
    {
        //ilki
        if (speed >= 5 && speed < 30)
        {
            _speedUI[0].gameObject.SetActive(true);
        }
        else { _speedUI[0].gameObject.SetActive(false); }


        //ikincisi
        if (speed >= 10 && speed < 30)
        {
            _speedUI[1].gameObject.SetActive(true);
        }
        else { _speedUI[1].gameObject.SetActive(false); }
       

        //üçüncüsü
        if (speed >= 15 && speed < 30)
        {
            _speedUI[2].gameObject.SetActive(true);

        }
        else { _speedUI[2].gameObject.SetActive(false); }

        //dördüncüsü
        if (speed >= 20 && speed < 30)
        {
                _speedUI[3].gameObject.SetActive(true);
        }
        else { _speedUI[3].gameObject.SetActive(false); }


        //beşincisi
        if (speed >= 25 && speed < 30)
        {
                _speedUI[4].gameObject.SetActive(true);
        }
        else { _speedUI[4].gameObject.SetActive(false); }

    }
}

