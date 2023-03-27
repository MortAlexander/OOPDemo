using System.IO;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;
    public Color BGColor;
    public Color PlayerColor;
    public Color ObstacleColor;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadColor();
    }
    public void SaveColor()
    {
        SaveData data = new SaveData();
        data.BGColor = BGColor;
        data.PlayerColor = PlayerColor;
        data.ObstacleColor = ObstacleColor;
        string json = JsonUtility.ToJson(data);
  
        File.WriteAllText(Application.persistentDataPath + "/savefilecolor.json", json);
    }
    public void LoadColor()
    {
        string path = Application.persistentDataPath + "/savefilecolor.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            BGColor =data.BGColor;
            PlayerColor  =data.PlayerColor;
            ObstacleColor =data.ObstacleColor;
        }
    }
    
    [System.Serializable]
    class SaveData
    {
        public Color BGColor;
        public Color PlayerColor;
        public Color ObstacleColor;
    }
}
