using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class UiHandler : MonoBehaviour
{
    public Text playerText;
    public Text BestScoreText;
    public Text LastScoreText;
    public GameObject TitleScreen;
    public GameObject SettingsScreen;
    public Slider BallSpeedSlider;
    public Slider PaddleSpeedSlider;
    public Slider PaddleSizeSlider;
    public Text BallSpeedText;
    public Text PaddleSpeedText;
    public Text PaddleSizeText;
    private float BestScore;
    private float LastScore;
    private string BestPlayer;
    private string LastPlayer;
    private float ScoreMulti;
    public Text ScoreMultiText;
    // Start is called before the first frame update
    void Start()
    {
        BestScore = GameManager.instance.BestScore;
        LastScore = GameManager.instance.LastScore;
        BestPlayer = GameManager.instance.BestPlayer;
        LastPlayer = GameManager.instance.LastPlayer;
        BallSpeedSlider.value = GameManager.instance.BallSpeedSetting;
        PaddleSpeedSlider.value = GameManager.instance.PaddleSpeedSetting;
        PaddleSizeSlider.value = GameManager.instance.PaddleSizeSetting;
        ScoreMulti = GameManager.instance.ScoreMulti;
        ScoreMultiText.text = $"Score Multiplier: x{ScoreMulti}";
        BestScoreText.text = $"Best Score: {BestPlayer} : {BestScore}";
        LastScoreText.text = $"Last Score: {LastPlayer} : {LastScore}";
    }

    // Update is called once per frame
    public void StartGame()
    {
        GameManager.instance.playername = playerText.text;
        SceneManager.LoadScene("main");  
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void Settings()
    {
        if (TitleScreen.activeSelf) 
        {
            TitleScreen.SetActive(false);
            SettingsScreen.SetActive(true);
        }
        else 
        {
            TitleScreen.SetActive(true);
            SettingsScreen.SetActive(false);
            GameManager.instance.SaveSettings();
        }

    }
    public void BallSpeed()
    {
        if(BallSpeedSlider.value == 1) { BallSpeedText.text = "Slow"; }
        if (BallSpeedSlider.value == 2) { BallSpeedText.text = "Normal"; }
        if (BallSpeedSlider.value == 3) { BallSpeedText.text = "Fast"; }
        GameManager.instance.BallSpeedSetting = BallSpeedSlider.value;
        ScoreCalc();
    }
    public void PaddleSpeed()
    {
        if (PaddleSpeedSlider.value == 3) { PaddleSpeedText.text = "Slow"; }
        if (PaddleSpeedSlider.value == 2) { PaddleSpeedText.text = "Normal"; }
        if (PaddleSpeedSlider.value == 1) { PaddleSpeedText.text = "Fast"; }
        GameManager.instance.PaddleSpeedSetting = PaddleSpeedSlider.value;
        ScoreCalc();
    }
    public void PaddleSize()
    {
        if (PaddleSizeSlider.value == 3) { PaddleSizeText.text = "Small"; }
        if (PaddleSizeSlider.value == 2) { PaddleSizeText.text = "Normal"; }
        if (PaddleSizeSlider.value == 1) { PaddleSizeText.text = "Large"; }
        GameManager.instance.PaddleSizeSetting = PaddleSizeSlider.value;
        ScoreCalc();
    }
    private void ScoreCalc()
    {
        double value = (int)BallSpeedSlider.value + (int)PaddleSpeedSlider.value + (int)PaddleSizeSlider.value;
        ScoreMulti = (float)System.Math.Round(value / 3, 2);
        ScoreMultiText.text = $"Score Multiplier: x{ScoreMulti}";
        GameManager.instance.ScoreMulti = ScoreMulti;

    }
}
