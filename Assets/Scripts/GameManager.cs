using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public string playername;
    public float BestScore;
    public string BestPlayer;
    public float LastScore;
    public string LastPlayer;
    public float BallSpeedSetting;
    public float PaddleSpeedSetting;
    public float PaddleSizeSetting;
    public float ScoreMulti;


    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
        Load();
        
    }
    private void Start()
    {
        //if (BallSpeedSetting == 0) { BallSpeedSetting = 1; }
        if (PaddleSpeedSetting == 0) { PaddleSpeedSetting = 1; }
        if (PaddleSizeSetting == 0) { PaddleSizeSetting = 1; }
        if (ScoreMulti == 0) { ScoreMulti = 1; }
    }
    [System.Serializable]
    class SaveData
    {
        public float BestScoreData;
        public string BestPlayerData;
        public float LastScoreData;
        public string LastPlayerData;
        public float BallSpeedSettingD;
        public float PaddleSpeedSettingD;
        public float PaddleSizeSettingD;
        public float ScoreMultiD;
    }

    public void Save()
    {
        SaveData data = new SaveData();
        data.BestScoreData = BestScore;
        data.BestPlayerData = BestPlayer;
        data.LastScoreData = LastScore;
        data.LastPlayerData = LastPlayer;
        

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile1.json", json);


    }
    public void SaveSettings() 
    {
        SaveData data1 = new SaveData();
        data1.BallSpeedSettingD = BallSpeedSetting;
        data1.PaddleSpeedSettingD = PaddleSpeedSetting;
        data1.PaddleSizeSettingD = PaddleSizeSetting;
        data1.ScoreMultiD = ScoreMulti;

        string json = JsonUtility.ToJson(data1);

        File.WriteAllText(Application.persistentDataPath + "/SaveSettings.json", json);
    }

    public void Load()
    {
        string path = Application.persistentDataPath + "/savefile1.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            BestScore = data.BestScoreData;
            BestPlayer = data.BestPlayerData;
            LastScore = data.LastScoreData;
            LastPlayer = data.LastPlayerData;
        }
        string path2 = Application.persistentDataPath + "/SaveSettings.json";
        if (File.Exists(path2)) 
        {
            string json = File.ReadAllText(path2);
            SaveData data1 = JsonUtility.FromJson<SaveData>(json);
            BallSpeedSetting = data1.BallSpeedSettingD;
            PaddleSpeedSetting = data1.PaddleSpeedSettingD;
            PaddleSizeSetting = data1.PaddleSizeSettingD;
            ScoreMulti = data1.ScoreMultiD;
        }

    }
}
