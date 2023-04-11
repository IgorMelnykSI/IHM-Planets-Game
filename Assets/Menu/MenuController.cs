using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [Header("Levels to Load")] 
    public string _newGameLevel;
    private string levelToLoad;
    [SerializeField] private GameObject noSavedGameDialog = null;

    public void NewGameDialogYes()
    {
        SceneManager.LoadScene(_newGameLevel);
    }
    // Not our case
    public void LoadGameDialogYes()
    {
        if (PlayerPrefs.HasKey("SavedLevel"))
        {
            levelToLoad = PlayerPrefs.GetString("SavedLevel");
            // PlayerPrefs.SetString("SavedLevel", levelToLoad);
            SceneManager.LoadScene(levelToLoad);
        }
        else
        {
            Debug.Log("No level saved");
            noSavedGameDialog.SetActive(true);
        }
    }

    public void LoadMuseum()
    {
        SceneManager.LoadScene("Museum");
    }

    public void LoadLab()
    {
        SceneManager.LoadScene("LabyrintheMortel");
    }

    public void LoadRace()
    {
        SceneManager.LoadScene("RaceScene");
    }

    public void LoadCoW()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
