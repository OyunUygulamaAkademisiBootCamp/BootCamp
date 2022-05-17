using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeightBarTemp : MonoBehaviour
{
    //using Lerp
    private float weight;
    private float lerpTimer;
    public float maxWeight = 100f;
    public float barSpeed = 1f;
    
    public Image BackWtBar;
    public Image FrontWtBar;

    void Start()
    {
        weight = maxWeight;
    }

    void Update()
    {
        weight = Mathf.Clamp(weight, 0, maxWeight);
        UpdateWeightUI();
        if (Input.GetKeyDown(KeyCode.W))
        {
            CarryObject(Random.Range(5, 10));
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            DropObject(Random.Range(5, 10));
        }
    }

    public void UpdateWeightUI()
    {
        Debug.Log(weight);
        float fillFront = FrontWtBar.fillAmount;
        float fillBack = BackWtBar.fillAmount;
        float wRatio = weight / maxWeight;
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

    public void CarryObject(float objectWeight)
    {
        weight -= objectWeight;
        lerpTimer = 0f;
    }

    public void DropObject(float objectAmount)
    {
        weight -= objectAmount;
    }
}
