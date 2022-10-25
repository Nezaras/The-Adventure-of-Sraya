using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void NewGame(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadGame()
    {
        //Ganti ke scene gameplay yang sudah di save sama playernya
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    void Awake(){
        Screen.lockCursor = false;
    }
}
