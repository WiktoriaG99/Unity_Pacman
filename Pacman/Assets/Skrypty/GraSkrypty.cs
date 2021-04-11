using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GraSkrypty : MonoBehaviour
{
    public Text HighScoreValue;
    public GameObject Pacman;
    public int GraLiczbaPunktow = 0;

    private void Start()
    {
        DaneGry.liczbaPunktow = 0;
        GraLiczbaPunktow = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) SceneManager.LoadScene(0);

        HighScoreValue.text = DaneGry.liczbaPunktow.ToString();

        //Koniec gry
        if(((DaneGry.liczbaRombow == 0) && (DaneGry.liczbaKropek == 0)) || (Pacman == null))
        {
            GraLiczbaPunktow = DaneGry.liczbaPunktow;
            SceneManager.LoadScene(2);
        }

    }


}
