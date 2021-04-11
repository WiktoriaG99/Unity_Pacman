using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuchDuch : MonoBehaviour
{
    
    public GameObject[] punkty;
    int obecnyPunkt = 0;
    Vector2 cel;
    public float szybkosc = 1f;
    float krok = 0.0f;
    bool wybierzNowyCel = false;
    void Start()
    {
        //Przypisanie początkowego celu
        cel = new Vector2(punkty[obecnyPunkt].transform.position.x, punkty[obecnyPunkt].transform.position.y);
    }
    
    void Update()
    {
        krok = szybkosc * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, cel, krok);
        
        if(wybierzNowyCel == true)
        {
            wybierzNowyCel = false;
            cel = new Vector2(punkty[obecnyPunkt].transform.position.x, punkty[obecnyPunkt].transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, cel, krok);
        }
        
    }

//Jeżeli wejście w Trigger, to przypisywany jest nowy cel
private void OnTriggerEnter2D(Collider2D other)
{
   if (other.tag == "waypoint")
    {
        wybierzNowyCel = true;
        if(obecnyPunkt+1 == punkty.Length) obecnyPunkt = 0;
        else obecnyPunkt++;
    }
}

//Kolizja z graczem = śmierć gracza
private void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.gameObject.tag == "pacman") Destroy(collision.gameObject);
}

}
