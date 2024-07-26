using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestionManager : MonoBehaviour
{
    public TextMeshProUGUI plakaText;
    public TextMeshProUGUI ipucuText;

    public List<Sehir> sehirler = new List<Sehir>();

    public GameObject questions;

    public Sehir randomSehir;
    public PlayerController playerController;

    private void Start()
    {
        randomSehir = sehirler[Random.Range(0, 82)];
        plakaText.text = "Plaka Kodu : " + randomSehir.plaka.ToString();
        ipucuText.text = "Ýpucu : " + randomSehir.ipucu;
    }

    private void Update()
    {
        if (playerController.dogru == true)
        {
            randomSehir = sehirler[Random.Range(0, sehirler.Count)];
            plakaText.text = "Plaka Kodu : " + randomSehir.plaka.ToString();
            ipucuText.text = "Ýpucu : " + randomSehir.ipucu;
            
        }
    }

    public void CloseQuestion()
    {
        questions.SetActive(false);
        playerController.gameStarted = true;
    }

    public void OpenQuestions()
    {
        playerController.dogru = false;
        questions.SetActive(true);
        playerController.gameStarted = false;
    }

    public void CloseGame()
    {
        SceneManager.LoadScene(0);
    }
}
