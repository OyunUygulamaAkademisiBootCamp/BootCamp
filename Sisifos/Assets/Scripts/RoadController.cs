using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Win32.SafeHandles;
using UnityEngine;

public class RoadController : MonoBehaviour
{
// Plane instantiation için yazıldı
    [SerializeField] private GameObject plane;
        
    [SerializeField] private int planeCount;
    public int planeAngle;
    private float planeLength;
    private Vector3 initialPosition;
    private Color[] colors = new []{Color.black, Color.blue, Color.cyan, Color.green, Color.red,Color.magenta, Color.white, Color.blue, Color.cyan, Color.red};
    private float relocateDistanceY, relocateDistanceZ, deltaY,deltaZ;
    private 
    
    // Start is called before the first frame update
    void Start()
    {
        planeLength = plane.transform.localScale.z*10;

        //eğimden dolayı y ve z nin sin cos ile hesaplanması gerekiyor. y'deki "-"  sin(-a) = - sin(a)'dan geliyor. açı negatif olduğu için düzeltmem gerekti
        //math.sin radyan hesaplıyor o yüzden * pi /180
        deltaY =  -Convert.ToSingle(planeLength * Math.Sin(planeAngle * Math.PI / 180));
        deltaZ = Convert.ToSingle(planeLength * Math.Cos(planeAngle * Math.PI / 180));
        
        // planeCount ile neden çarptım? bir sonraki lokasyonla ilk lokasyon arasında sahnedeki plane sayısı * o enlemdeki yükseklikleri kadar fark olacak  
        relocateDistanceY = planeCount * deltaY;
        relocateDistanceY = planeCount * deltaZ;
        
        initialPosition = transform.position;
        for (int i = 0; i < planeCount; i++)
        {
          
            float _y = i * deltaY;
            float _z = i * deltaZ;
            
            GameObject createdPlane =  Instantiate(plane, new Vector3(0,_y,_z),  Quaternion.Euler(new Vector3(planeAngle, 0, 0)));
            
        }
        transform.position = initialPosition;
    }

    public void RelocatePlane(GameObject _gameObject)
    { 
        
        //önceki pozisyonla topladığım için kaçıncı kez relocate edildiği önemli değil 
        _gameObject.transform.position += new Vector3(0, relocateDistanceY, relocateDistanceZ);
    }
}
