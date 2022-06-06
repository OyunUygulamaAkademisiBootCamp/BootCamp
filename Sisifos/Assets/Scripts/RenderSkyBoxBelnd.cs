using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderSkyBoxBelnd : MonoBehaviour
{
    public Material[] materialList;
    
   
    



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

   


}
