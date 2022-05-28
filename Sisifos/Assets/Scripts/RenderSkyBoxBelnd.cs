using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderSkyBoxBelnd : MonoBehaviour
{
    public Material[] materialList;
    //public Material skyOne;
    //public Material skyTwo;
    //public Material skyThree;
    float timeLeft = 3.0f;
    float secondTimeLeft = 6.0f;
    float thirdTimeLeft = 9.0f;
    float fourthTimeLeft = 12.0f;



    private void Start()
    {
        //RenderSettings.skybox = materialList[1];
        StartCoroutine(ChangeMaterials());
    }


    private IEnumerator ChangeMaterials()
    {
        while (true)
        {
            foreach (Material material in materialList)
            {
                RenderSettings.skybox = material;
                yield return new WaitForSeconds(3);
            }
        }
    }

    private void Update()
    {
        // if (timeLeft < 0)
        // {
        //     print("skyTwo");
        //     RenderSettings.skybox = skyTwo;
        // }
        //
        // if (timeLeft + 3 < 0)
        // {
        //     print("skyThree");
        //     RenderSettings.skybox = skyThree;
        // }
        // if (timeLeft + 6 < 0)
        // {
        //     print("skyOne");
        //     RenderSettings.skybox = skyOne;
        // }
        // if (fourthTimeLeft < 0)
        //
        // {
        //     RenderSettings.skybox = skyTwo;
        // }

        //DynamicGI.UpdateEnvironment();
    }


}
