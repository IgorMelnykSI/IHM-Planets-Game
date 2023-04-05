using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
        //Controls
    public GameObject capsuleMovement;


    private bool backInterfaceOnScreen = false;

    public GameObject backInterface;


    void Start() {
        Resume();    
    }


    public void Resume()
    {
        backInterface.SetActive(false);
        backInterfaceOnScreen = false;
    }

    void Pause()
    {
        backInterface.SetActive(true);
        backInterfaceOnScreen = true;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }


    void Update()
    {
        OnEscape();
    }


        public void OnEscape()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (backInterfaceOnScreen == false)
            {
                Cursor.lockState = CursorLockMode.None;

                capsuleMovement.SetActive(false);

                Cursor.visible = true;
                backInterface.SetActive(true);
                backInterfaceOnScreen = true;
            } else
            {
                // Pause menu become invisible
                backInterface.SetActive(false);
                backInterfaceOnScreen = false;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                capsuleMovement.SetActive(true);
            }
        }
    }

    
}
