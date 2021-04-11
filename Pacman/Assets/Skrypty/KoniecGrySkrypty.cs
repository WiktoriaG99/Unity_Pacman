using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KoniecGrySkrypty : MonoBehaviour
{

    public Text HighScoreEndGameValue;
    public InputField NazwaValue;
    int indexTabela = 0;
    int wynik = 0;
    bool czyDoHS = false;
    public GameObject NewRecord;

    private void Awake()
    {
        Wynik();
    }

    void Wynik()
    {
        wynik = DaneGry.liczbaPunktow;
        HighScoreEndGameValue.text = wynik.ToString();

        //Czy wynik kwalifikuje się jako nowa pozycja w HighScore
        int x = DaneGry.TabelaWynikow.Length - 1;
        while(x>=0)
        {
            if (wynik > DaneGry.TabelaWynikow[x])
            {
                //Index - pozycja, którą nowy wynik zajmie
                indexTabela = x;
                //Czy wynik do HighScore
                czyDoHS = true;
            }
            x--;
        }


        if (czyDoHS == true)
        {
            NewRecord.SetActive(true);

            //Ustawienie nowego wyniku w ostatniej pozycji HighScore
            DaneGry.TabelaWynikow[DaneGry.TabelaWynikow.Length-1] = wynik;
            DaneGry.TabelaNazw[DaneGry.TabelaWynikow.Length-1] = NazwaValue.text;

            //Sortowanie malejąco HighScore
            int i = 0;
            while (i < DaneGry.TabelaWynikow.Length)
            {
                int j = i + 1;
                while(j<DaneGry.TabelaWynikow.Length)
                {
                    if (DaneGry.TabelaWynikow[i] < DaneGry.TabelaWynikow[j])
                    {
                        int tempWynik = DaneGry.TabelaWynikow[i];
                        string tempNazwa = DaneGry.TabelaNazw[i];

                        DaneGry.TabelaWynikow[i] = DaneGry.TabelaWynikow[j];
                        DaneGry.TabelaNazw[i] = DaneGry.TabelaNazw[j];

                        DaneGry.TabelaWynikow[j] = tempWynik;
                        DaneGry.TabelaNazw[j] = tempNazwa;
                    }
                    j++;
                }
                i++;
            }
        }
    }

    public void PrzeslijDoHS()
    {
        if (czyDoHS == true)
        {
            //Przesłanie wyniku do HighScore
            DaneGry.TabelaWynikow[indexTabela] = wynik;
            DaneGry.TabelaNazw[indexTabela] = NazwaValue.text;
        }

        //Przeslanie do PlayerPrefs
        for(int i =0; i<DaneGry.TabelaWynikow.Length;i++)
        {
            PlayerPrefs.SetInt(("Wynik{0}" + i), DaneGry.TabelaWynikow[i]);
            PlayerPrefs.SetString(("Nazwa{0}" + i), DaneGry.TabelaNazw[i]);
            PlayerPrefs.Save();
        }

    }

    public void WyjdzdoMenuButton()
    {
        SceneManager.LoadScene(0);
    }
}
