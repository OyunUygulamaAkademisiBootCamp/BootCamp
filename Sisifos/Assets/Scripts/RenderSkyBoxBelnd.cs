using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.DynamicGI;

public class RenderSkyBoxBelnd : MonoBehaviour
{
    public Material skyOne;
    public Material skyTwo;
    public Material skyThree;
    float timeLeft =3.0f;
    float secondTimeLeft = 6.0f;
    float thirdTimeLeft = 9.0f;
    float fourthTimeLeft = 12.0f;



    private void Start()
    {
        RenderSettings.skybox = skyOne;
    }

    
    
    private void Update()
    {

        timeLeft -= Time.deltaTime;

        if (timeLeft < 0)
        {
            RenderSettings.skybox = skyTwo;
        }

        if (secondTimeLeft < 0)
        {
            RenderSettings.skybox = skyThree;
        }
        if (thirdTimeLeft < 0)
        {
            RenderSettings.skybox = skyOne;
        }
        if (fourthTimeLeft < 0)
        
        {
            RenderSettings.skybox = skyTwo;
        }

        DynamicGI.UpdateEnvironment();
    }


}
