using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuchPacMan : MonoBehaviour
{
    public AudioSource zrodloDzwieku;
    public AudioClip plikDzwiekuWakaWaka;
    public float szybkosc = 1.0f;
    void Update()
    {
        float h = Input.GetAxis("Horizontal") * Time.deltaTime * szybkosc;
        float v = Input.GetAxis("Vertical") * Time.deltaTime * szybkosc;
        transform.Translate(h, v, 0);
    }

    //Dźwięk "WakaWaka" podczas zebrania punktu
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "punkt")
        {
            this.GetComponent<AudioSource>().PlayOneShot(plikDzwiekuWakaWaka);
        }
    }
}
