using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuSkrypty : MonoBehaviour
{

    public Canvas Menu;
    public Canvas HighScore;
    public Text [] HsWyniki;
    public Text[] HsNazwa;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
    }

    public void StartGry()
    {
        SceneManager.LoadScene(1);
    }

    public void WejdzHighScore()
    {
        Menu.enabled = false;
        HighScore.enabled = true;
    }

    public void PowrotdoMenu()
    {
        HighScore.enabled = false;
        Menu.enabled = true;
    }
    public void AktualizacjaWynikow()
    {  
       //Pobranie wyników z PlayerPrefs
       for(int i =0; i<DaneGry.TabelaWynikow.Length;i++)
       {
            HsWyniki[i].text = PlayerPrefs.GetInt(("Wynik{0}" + i)).ToString();
            HsNazwa[i].text = PlayerPrefs.GetString(("Nazwa{0}" + i));
       }
    }
    public void WyjscieZGry()
    {
        Application.Quit();
    }
}
