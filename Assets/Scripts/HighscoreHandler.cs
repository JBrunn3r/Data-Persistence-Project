using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class HighscoreHandler : MonoBehaviour
{
    public static HighscoreHandler Instance;
    public TextMeshProUGUI highscoreField;
    public string savedName;
    public int savedHighscore;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        highscoreField.text = GenerateHighscoreText();
    }

    [System.Serializable]
    class SaveData
    {
        public string savedName;
        public int savedHighscore;
    }

    public void SaveHighscore()
    {
        SaveData data = new SaveData();
        data.savedName = MenuUiHandler.playerName;
        data.savedHighscore = MainManager.m_Points;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public bool LoadHighscore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            savedName = data.savedName;
            savedHighscore = data.savedHighscore;
            return true;
        }
        else
        {
            return false;
        }
    }

    public string GenerateHighscoreText()
    {
        if (LoadHighscore())
        {
            return savedName + " - " + savedHighscore;
        }
        else
        {
            Debug.Log("Highscore was loaded.");
            return "-";
        }
    }
}
