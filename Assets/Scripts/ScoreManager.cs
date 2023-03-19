using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public GameData ScoreData;
    public string currentPlayerName;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadScore();
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        
    }

    public void SaveScore()
    {
        string scoreDataJson = JsonUtility.ToJson(ScoreData);
        string path = Path.Combine(Application.persistentDataPath, "ScoreData.json");
        File.WriteAllText(path, scoreDataJson);
    }

    public bool LoadScore()
    {
        string path = Path.Combine(Application.persistentDataPath, "ScoreData.json");
        if (File.Exists(path))
        {
            string scoreDataJson = File.ReadAllText(path);
            ScoreData = JsonUtility.FromJson<GameData>(scoreDataJson);
            return true;
        }
        return false;
    }

    [System.Serializable]
    public class GameData
    {
        public int highScore;
        public string playerName;
    }
}
