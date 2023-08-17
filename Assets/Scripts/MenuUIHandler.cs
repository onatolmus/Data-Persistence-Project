using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif
using TMPro;
using UnityEngine.UI;


public class MenuUIHandler : MonoBehaviour
{

    public TextMeshProUGUI bestScoreTextMenu;

    private void Start()
    {
        // Load the best score and name at the start
        MenuManager.Instance.LoadBestScoreAndName();
        bestScoreTextMenu.text = $"Best Score : {MenuManager.Instance.bestScoreName} : {MenuManager.Instance.bestScore}";

    }



    public void StartNew()
    {
        MenuManager.Instance.GetUserName();
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
        MenuManager.Instance.SaveBestScoreAndName();

        #if UNITY_EDITOR

            EditorApplication.ExitPlaymode();

        #else
        
            Application.Quit(); // original code to quit Unity player
        #endif
    }

    //public void ReadUserNameInput(string newName)
    //{
    //    MenuManager.Instance.username = newName;
    //    Debug.Log(MenuManager.Instance.username);

    //}
}
