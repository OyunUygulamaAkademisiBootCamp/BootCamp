
using UnityEngine;

public class PlaneSpawner : MonoBehaviour
{
    private float _z; 
    private float _y;
    private float _x;
    private Vector3 pos;
    
    public GameObject planeObj;
    public Transform playerTransform;
    public bool isCreated = false;
    
    // Ne kadar plane oluşacağına dair bir değişken. Fakat fonksiyon Update içerisindeyken while/for/?? nasıl kullanılabilir?
    public int planeCount = 10; 
    
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
        // Spawn olacak yeni Plane için position (Değerler sahnedeki plane'e göre yapıldı, gerekirse değişebilir.)
        pos = new Vector3(_x, _y + 25, _z + 43.30127f); 
        
        // Sonsuz spawndan kaçınmak için isCreated booleanı kullanıldı.
        if (isCreated == false)
            {
                /*
                   Player'ın konumuna göre Instantiate yapıldı.
                   Player Plane'in konumundan 100 birim gerideyse Instantiate konumu çalışıyor.
                   100 birim olmasının sebebi ekrandan bakıldığından ufuktaki spawnın bariz belli olmamasıdır. 100 birim değişebilir.
                */
                
                if (playerTransform.position.y >= pos.y - 100)
                {
                    Instantiate(planeObj, pos, Quaternion.identity);
                    isCreated = true; //Plane oluştuktan sonra true çeviriliyor ve aynı plane sonsuza kadar oluşmuyor.
                }
            }
        
        // Player, arkasında kalan Plane'den y düzleminde 5 birim uzaklaştığında o Plane'i yok ediyor.
        if (playerTransform.position.y >= pos.y + 5)
            {
                Destroy(gameObject);
            }
        
        }
    
    //ToDo: OnBecameInvisible saçma çalışıyor. Bu yüzden üstteki if bloğunu kullandım. Düzeltmenin bir yolu olursa üstteki if bloğundan daha mantıklı olabilir.
    
    //void OnBecameInvisible()
    //{
    //    Destroy(gameObject);
    //    Debug.Log("Destroyed");
    //}

}
