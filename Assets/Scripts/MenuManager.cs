using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.IO;

public class MenuManager : MonoBehaviour
{

    public static MenuManager Instance;
    public string username;
    public TMP_InputField inputField;

    public int bestScore;
    public string bestScoreName;


    private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);

        // load best score and username
        LoadBestScoreAndName();

    }

    public void GetUserName()
    {
        username = inputField.text;
        //Debug.Log(username);
    }

    [System.Serializable]
    class SaveData
    {
        public int bestScore;
        public string bestScoreName;
    }

    public void SaveBestScoreAndName()
    {
        SaveData data = new SaveData();
        data.bestScore = bestScore;
        data.bestScoreName = bestScoreName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadBestScoreAndName()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestScore = data.bestScore;
            bestScoreName = data.bestScoreName; 
        }
    }

}
