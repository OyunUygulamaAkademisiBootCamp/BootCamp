using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Leveli geçtiğini gösteren şeyler burada yapılabilir.
            Debug.Log("Tebrikler. Bölümü başarıyla bitirdiniz.");
            Time.timeScale = 0;
        }
    }
}
