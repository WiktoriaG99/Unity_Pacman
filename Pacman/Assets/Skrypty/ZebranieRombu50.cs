using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZebranieRombu50 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "pacman")
        {
            Destroy(gameObject);
            DaneGry.liczbaPunktow += 50;
            DaneGry.liczbaRombow--;
        }
    }
}
