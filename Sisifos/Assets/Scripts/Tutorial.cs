using TMPro;
using UnityEngine;


public class Tutorial : MonoBehaviour
{
    private int index = 0;

    private bool tutorial, right, left, positive, negative, hole, obstacle, weight, done;
    public GameObject[] popups;
    public GameObject panel;
    private float ScreenWidth;
    private PlaneSpawner _planeSpawner;
    private Player _player;
    
    // Start is called before the first frame update
    void Start()
    {
        _planeSpawner = FindObjectOfType<PlaneSpawner>();
        _player = FindObjectOfType<Player>();
        ScreenWidth = Screen.width;
    }

    // Update is called once per frame
    void Update()
    {
        //Tutorial'ı hızlıca bitiremeyenler için level uzunluğu arttırma
        if (_planeSpawner.planeCount >= _planeSpawner.levelPlane - 3 && index != 5)
        {
            Debug.Log("Level plane added");
            _planeSpawner.levelPlane += 5;
        }
        else
        {
            Debug.Log("pC: " + _planeSpawner.planeCount + ", lP: " + _planeSpawner.levelPlane + ", index: " + index);
            
        }
    
        switch (index)
        {
            //sağ sol hareket
            case 0:
                int i = 0;
                popups[index].SetActive(true);
                while (i < Input.touchCount)
                {
                    if (Input.GetTouch(i).position.x < ScreenWidth / 2)
                    {
                        left = true;
                    }

                    if (Input.GetTouch(i).position.x > ScreenWidth / 2)
                    {
                        right = true;
                    }

                    i++;
                }

                if (left && right)
                {
                    popups[index].SetActive(false);
                    index++;
                }

                break;
            //pozitif objeler
            case 1:
                popups[index].SetActive(true);
                if (positive)
                {
                    popups[index].SetActive(false);
                    index++;
                }

                break;
            //negatif objeler
            case 2:
                popups[index].SetActive(true);
                if (negative)
                {
                    popups[index].SetActive(false);
                    index++;
                }

                break;
            //hole
            case 3:
                popups[index].SetActive(true);
                if (hole)
                {
                    popups[index].SetActive(false);
                    index++;
                }

                break;
            //obstacle
            case 4:
                popups[index].SetActive(true);
                if (obstacle)
                {
                    popups[index].SetActive(false);
                    index++;
                }

                break;
            //weight
            case 5:
                popups[index].SetActive(true);
                if (weight)
                {
                    done = true;
                }

                break;

        }

        if (done)
        {
            panel.SetActive(false);
            PlayerPrefs.SetInt("Tutorial", 1);
        }
        




    }

    private void OnTriggerEnter(Collider other)
    {
        if (index == 1 && other.CompareTag("Positive"))
        {
            positive = true;
        }
        else if (index == 2 && other.CompareTag("Negative"))
        {
            negative = true;
        }
        else if (index == 3 && other.CompareTag("Hole") && !_player.isDangerZone)
        {
            hole = true;
        }
        else if (index == 4 && other.CompareTag("Obstacle") && _player.isDangerZone )
        {
            obstacle = true;
        }
        else if (index == 5 && other.CompareTag("Finish"))
        {
            weight = true;
        }
    }

}
