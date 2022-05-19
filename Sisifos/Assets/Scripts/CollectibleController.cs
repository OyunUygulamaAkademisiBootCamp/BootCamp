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
    
    //private float lerpTimer;
    //public float barSpeed = 1f;

    //public Image BackWtBar;
    //public Image FrontWtBar;
    
    void Start()
    {
        weight = maxWeight/2;
    }

    // Update is called once per frame
    void Update()
    {

        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("CollectibleRed"))
        {
            Destroy(other.gameObject);
           
            boulder.transform.localScale = new Vector3(boulder.transform.localScale.x + sizeMultiplier, boulder.transform.localScale.y + sizeMultiplier,
                boulder.transform.localScale.z + sizeMultiplier);
            
            weight += Random.Range(5, 10);
            
            Debug.Log(boulder.transform.localScale.x);
            
            if (boulder.transform.localScale.x > maxWeight/50)
            {
                //Oyunu durdur (animasyon vs girsin + Game Over)
                Time.timeScale = 0;

            }
            
            
            Debug.Log("Boulder size: +++");
            

        }
        
        if (other.CompareTag("CollectibleGreen"))
        {
            Destroy(other.gameObject);
            boulder.transform.localScale = new Vector3(boulder.transform.localScale.x - sizeMultiplier, boulder.transform.localScale.y - sizeMultiplier,
                boulder.transform.localScale.z - sizeMultiplier);
            
            
            weight -= Random.Range(5, 10);
            
            if (boulder.transform.localScale.x < maxWeight/800)
            {
                //Oyunu durdur (animasyon girsin + Game Over)
                Time.timeScale = 0;

            }
            
            Debug.Log("Boulder size: ---");
            
            
        }
    }
    
    
}
