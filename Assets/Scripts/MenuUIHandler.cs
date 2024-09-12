using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField inputNameField;
    public TMP_Text highScoreText;

    private DataManager dataManager;

    private string playerName;

    private void Start()
    {
        dataManager = DataManager.Instance;
        highScoreText.text = "High score: " + dataManager.highName + ' ' + dataManager.highScore;
    }

    public void NameChange(string text)
    {
        playerName = text;
    }
    public void StartGame()
    {
        // not allowing to start game without name
        if (string.IsNullOrEmpty(playerName))
        {
            inputNameField.placeholder.color = Color.red;
        }
        else
        {
            dataManager.playerName = playerName;
            SceneManager.LoadScene(1);
        }
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

}
