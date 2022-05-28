using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeightBarTemp : MonoBehaviour
{
    
    public CollectibleController collectibleController;
    
    private float lerpTimer;
    public float barSpeed = 1f;
    
    public Image BackWtBar;
    public Image FrontWtBar;

    void Start()
    {
        
    }

    void Update()
    {
        
        collectibleController.boulderWeight = Mathf.Clamp(collectibleController.boulderWeight, 0, collectibleController.maxWeight);
        UpdateWeightUI();
        
    }

    public void UpdateWeightUI()
    {
        
        float fillFront = FrontWtBar.fillAmount;
        float fillBack = BackWtBar.fillAmount;
        float wRatio = collectibleController.boulderWeight / collectibleController.maxWeight;
        if(fillBack > wRatio)
        {
            FrontWtBar.fillAmount = wRatio;
            //BackWtBar.color = Color.blue;
            lerpTimer += Time.deltaTime;
            float ratioAmount = lerpTimer / barSpeed;
            ratioAmount = ratioAmount * ratioAmount;
            BackWtBar.fillAmount = Mathf.Lerp(fillBack, wRatio, ratioAmount);
        }
        if(fillFront < wRatio)
        {
            //BackWtBar.color = Color.green;
            BackWtBar.fillAmount = wRatio;
            lerpTimer += Time.deltaTime;
            float ratioAmount = lerpTimer / barSpeed;
            ratioAmount = ratioAmount * ratioAmount;

            FrontWtBar.fillAmount = Mathf.Lerp(fillFront, BackWtBar.fillAmount, ratioAmount);
        }
    }
    
}
