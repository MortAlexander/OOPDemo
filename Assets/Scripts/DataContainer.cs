using System;
using System.IO;
using UnityEngine;
using UnityEngine.Events;

public class DataContainer : MonoBehaviour
{
    public static DataContainer Instance;
    public String NameFromJson;
    public int ScoreFromJson=0;
    public String CurentName;
    public int Score=0;
    public  UnityEvent TopScoreChanged;
    public  UnityEvent DataLoaded;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DataLoaded.AddListener(GameController.Instance.UpdateStartTopScore);
        LoadName();
        TopScoreChanged.AddListener(ChangeCurrentTopData);
        TopScoreChanged.AddListener(SaveName);
        
    }
    public void SaveName()
    {
        SaveData data = new SaveData();
        data.Name = CurentName;
        data.Score = Score;

        string json = JsonUtility.ToJson(data);
  
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadName()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            NameFromJson = data.Name;
            CurentName = data.Name;
            ScoreFromJson= data.Score;
            if (DataLoaded!=null)
            {
                Debug.Log("DataLoaded.Invoke()");
                DataLoaded.Invoke();
            }
        }
    }

    public void SetPLayerName(string name)
    {
        CurentName = name;
    }

    public void ResetScore()
    {
        Score = 0;
    }

    public void CheckGameResult(int _score)
    {
        if (_score>Score)
        {
            Score = _score;
           // SaveName();
            if (TopScoreChanged!=null)
            {
                TopScoreChanged.Invoke();
            }
        }
    }

    private void ChangeCurrentTopData()
    {
        NameFromJson = CurentName;
        ScoreFromJson = Score;
    }
    [System.Serializable]
    class SaveData
    {
        public String Name;
        public int Score;
    }
}
