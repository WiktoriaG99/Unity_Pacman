using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZebranieKropki10 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "pacman")
        {
            Destroy(gameObject);
            DaneGry.liczbaPunktow += 10;
            DaneGry.liczbaKropek--;
        }
    }
}
