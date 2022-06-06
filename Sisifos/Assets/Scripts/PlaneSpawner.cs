
using UnityEngine;

public class PlaneSpawner : MonoBehaviour
{
    private float _z; 
    private float _y;
    private float _x;
    private Vector3 pos;
    private Vector3 posbitis;
    
    public GameObject finishPlaneObj;
    public Transform playerTransform;
    public bool isCreated = false;
    
    // Ne kadar plane oluşacağına dair bir değişken. Fakat fonksiyon Update içerisindeyken while/for/?? nasıl kullanılabilir?
    public int planeCount = 1;
    public int levelPlane = 5;
    
    void Start()
    {
        
        _z = transform.localPosition.z; // Başlangıçta Plane'in Pivot'unun z konumu
        _y = transform.localPosition.y; // Başlangıçta Plane'in Pivot'unun y konumu
        _x = transform.localPosition.x; // Başlangıçta Plane'in Pivot'unun x konumu

        
    }

    void Update()
    {
        // Plane spawnlamak için kullanılan fonksiyon
        PlaneSpawning();

    }

    void PlaneSpawning()
    {
        //TODO: 20 34.641 değişecek
        // Spawn olacak yeni Plane için position (Değerler sahnedeki plane'e göre yapıldı, gerekirse değişebilir.)
        pos = new Vector3(_x, _y + 20, _z + 34.641f);
        posbitis = new Vector3(_x, _y, _z);

        
            // Sonsuz spawndan kaçınmak için isCreated booleanı kullanıldı.
            if (isCreated == false)
            {
                /*
                   Player'ın konumuna göre Instantiate yapıldı.
                   Player Plane'in konumundan 100 birim gerideyse Instantiate konumu çalışıyor.
                   100 birim olmasının sebebi ekrandan bakıldığından ufuktaki spawnın bariz belli olmamasıdır. 100 birim değişebilir.
                */
                
                    
                    if (playerTransform.position.y >= pos.y - 50 && planeCount < levelPlane)
                    {
                        planeCount++;
                        Instantiate(gameObject, pos, Quaternion.identity);
                        isCreated = true; //Plane oluştuktan sonra true çeviriliyor ve aynı plane sonsuza kadar oluşmuyor.
                     
                    }
                    
                    else if (playerTransform.position.y >= pos.y - 50 && planeCount >= levelPlane)
                    {
                        Instantiate(finishPlaneObj, new Vector3(transform.position.x,transform.position.y, transform.position.z), Quaternion.identity);
                        isCreated = true;
                        Debug.Log("Finish Plane'i oluşturuldu.");
                    }
                    
            }

        
        

        // Player, arkasında kalan Plane'den y düzleminde 5 birim uzaklaştığında o Plane'i yok ediyor.
        if (playerTransform.position.y >= pos.y + 5)
        {
            Destroy(gameObject);
        }
    
    }
}
