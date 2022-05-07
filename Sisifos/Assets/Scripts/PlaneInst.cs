using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneInst : MonoBehaviour
{

    [SerializeField] private GameObject plane;

    public int planeCount;
    private float planeLength;
    private Vector3 initialPosition;
    private Color[] colors = new []{Color.black, Color.blue, Color.cyan, Color.green, Color.red,Color.magenta, Color.white, Color.blue, Color.cyan, Color.red};
    
    // Start is called before the first frame update
    void Start()
    {
        
        Debug.Log(transform.position);
        planeLength = plane.transform.localScale.x;
        Debug.Log("plane length: " + planeLength);
        initialPosition = transform.position;
        
        
        for (int x = 0; x < planeCount; x++)
        {
            if(x!=0)
                transform.position = transform.position + new Vector3(0, 0, planeLength);
            
            Debug.Log("transform.position:"+ transform.position.ToString());
            
            GameObject createdPlane =  Instantiate(plane, transform);
            createdPlane.GetComponent<Renderer>().material.color = colors[x];
            //ToDo: tek bir obje gibi davranıyor neden
        }

        transform.position = initialPosition;


    }
    
}
