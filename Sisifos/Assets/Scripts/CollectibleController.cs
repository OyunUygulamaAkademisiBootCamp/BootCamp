using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectibleController : MonoBehaviour
{
    public float sizeMultiplier;
    
    public GameObject boulder;

    public float maxSize;
    public float minSize;

    public float weight;
    public float maxWeight = 100.0f;
    
    void Start()
    {
        weight = maxWeight/2;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(weight);
        
        //
        // BOYUT BÜYÜLTENLER
        //
        
        if (other.CompareTag("UpTag"))
        {
            Destroy(other.gameObject);
            UpScale();
            weight += 5;
        }
        
        if (other.CompareTag("CovidTag"))
        {
            Destroy(other.gameObject);
            UpScale();
            weight += 10;
        }
        
        
        //
        // BOYUT KÜÇÜLTENLER
        //
        
        if (other.CompareTag("HealthTag"))
        {
            Destroy(other.gameObject);
            DownScale();
            weight -= 10;
        }
        
        if (other.CompareTag("FamilyTag"))
        {
            Destroy(other.gameObject);
            DownScale();
            weight -= 8;
        }
        
        if (other.CompareTag("MoneyTag"))
        {
            Destroy(other.gameObject);
            DownScale();
            weight -= 7;
        }
        
        if (other.CompareTag("LoveTag"))
        {
            Destroy(other.gameObject);
            DownScale();
            weight -= 6;
        }
        
        if (other.CompareTag("WorkTag"))
        {
            Destroy(other.gameObject);
            DownScale();
            weight -= 5;
        }
        
        
    }

    private void UpScale()
    {
        boulder.transform.localScale = new Vector3(
            boulder.transform.localScale.x + sizeMultiplier, 
            boulder.transform.localScale.y + sizeMultiplier,
            boulder.transform.localScale.z + sizeMultiplier
        );
        
        if (boulder.transform.localScale.x > maxWeight/50)
        {
            //Oyunu durdur (animasyon vs girsin + Game Over)
            Time.timeScale = 0;
        }
        
        Debug.Log("Boyut Büyüdü");
        
        
    }
    
    private void DownScale()
    {
        boulder.transform.localScale = new Vector3(
            boulder.transform.localScale.x - sizeMultiplier, 
            boulder.transform.localScale.y - sizeMultiplier,
            boulder.transform.localScale.z - sizeMultiplier
            );

        if (boulder.transform.localScale.x < maxWeight/800)
        {
            //Oyunu durdur (animasyon girsin + Game Over)
            Time.timeScale = 0;

        }
        Debug.Log("Boyut Küçüldü");
        
    }

    
    
    
}
