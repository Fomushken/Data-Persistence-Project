using System.IO;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance { get; private set; }
    
    public List<Player> Players;
    public int bestScore;
    public string bestPlayerName;
    public Player currentPlayer;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            Players = new List<Player>();
            Load();
            Debug.Log($"DataManager loaded. Best player name is {bestPlayerName} and score is {bestScore}");
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }

    public class Player
    {
        public string PlayerName;
        public int BestScore;
    }

    class SaveData
    {
        // public Player[] Players;
        public int BestScore;
        public string BestPlayerName;
    }

    public bool HighScore(int score)
    {
        if (score > bestScore)
        {
            bestScore = score;
            bestPlayerName = currentPlayer.PlayerName;
            currentPlayer.BestScore = bestScore;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Save()
    {
        SaveData data = new SaveData();
        // data.Players = Players.ToArray();
        data.BestScore = bestScore;
        data.BestPlayerName = bestPlayerName;
        File.WriteAllText(Application.persistentDataPath + "/players.json", JsonUtility.ToJson(data));
    }

    public void Load()
    {
        string path = Application.persistentDataPath + "/players.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            // Players = data.Players.ToList();
            bestScore = data.BestScore;
            bestPlayerName = data.BestPlayerName;
        }
    }

    public void Delete()
    {
        string path = Application.persistentDataPath + "/players.json";
        File.Delete(path);
    }
}
