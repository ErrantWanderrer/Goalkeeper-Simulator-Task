using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainScript : MonoBehaviour
{

    [SerializeField] private float time;
    [SerializeField] private Text timerText;

    public GameObject Player;
    public GameObject Game_controller;
    private float _timeLeft = 0f;
    public Image ProgressBar;
    public GameObject WinImage;
    public GameObject LoseImage;
    public GameObject ReloadButtn;


    void Start()
    {
        if (!PlayerPrefs.HasKey("Coins"))
        {
            PlayerPrefs.SetInt("Coins", 0);
        }

        _timeLeft = time;
    }

    void Update()
    {
        if(_timeLeft<=0 && ProgressBar.GetComponent<Image>().fillAmount == 1)
        {
            Player.SetActive(false);
            Game_controller.SetActive(false);
            WinImage.SetActive(true);
            ReloadButtn.SetActive(true);
        }
        else if (_timeLeft <= 0 && ProgressBar.GetComponent<Image>().fillAmount < 1)
        {
            Player.SetActive(false);
            Game_controller.SetActive(false);
            LoseImage.SetActive(true);
            ReloadButtn.SetActive(true);
        }
    }

    public void TimerActivate()
    {
        StartCoroutine(StartTimer());
    }

    private IEnumerator StartTimer()
    {
        while (_timeLeft > 0)
        {
            _timeLeft -= Time.deltaTime;
            UpdateTimeText();
            yield return null;
        }
    }

    private void UpdateTimeText()
    {
        if (_timeLeft < 0)
            _timeLeft = 0;

        float minutes = Mathf.FloorToInt(_timeLeft / 60);
        float seconds = Mathf.FloorToInt(_timeLeft % 60);
        timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }

    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
