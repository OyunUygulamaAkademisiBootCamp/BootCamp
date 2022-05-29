using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeightBarTemp : MonoBehaviour
{
    
    public CollectibleController collectibleController;
    public Image FrontWtBar;
    
    

    void Start()
    {
        FrontWtBar.fillAmount = collectibleController.boulderWeight / collectibleController.maxWeight;
        

    }

    void Update()
    {
        
        collectibleController.boulderWeight = Mathf.Clamp(collectibleController.boulderWeight, 0, collectibleController.maxWeight);
        UpdateWeightUI();
        
    }

    public void UpdateWeightUI()
    {
        
        float fillFront = Convert.ToSingle(Math.Round(FrontWtBar.fillAmount,2));
        float wRatio = collectibleController.boulderWeight / collectibleController.maxWeight;
        if(fillFront > wRatio)
        {
            //FrontWtBar.fillAmount = wRatio;
            //BackWtBar.color = Color.blue;
            FrontWtBar.fillAmount -= 0.01f; // Mathf.Lerp(fillBack, wRatio, ratioAmount);
        }
        if(fillFront < wRatio)
        {
            //BackWtBar.color = Color.green;
            
            FrontWtBar.fillAmount += 0.01f; //= Mathf.Lerp(fillFront, BackWtBar.fillAmount, ratioAmount);
        }
    }
    
}
