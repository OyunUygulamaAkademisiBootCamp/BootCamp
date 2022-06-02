using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator zuusAnim;
    [SerializeField] private GameObject zuus; 

    private void Start()
    {
        zuus.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Hole"))
        {
            zuus.SetActive(true);
            zuusAnim.Play("ZeusStrike");
            Debug.Log("düseyrumm");
            Destroy(other.gameObject);
        }
    }
}
