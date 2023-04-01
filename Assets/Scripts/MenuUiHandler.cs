using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]
public class MenuUiHandler : MonoBehaviour
{
    public static string playerName = "No Name";

    void Start()
    {

    }

    public void StartNewGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #else
        Application.Quit();
        #endif
    }

    public void ReadStringInput(string textInput)
    {
        playerName = textInput;
    }
}
