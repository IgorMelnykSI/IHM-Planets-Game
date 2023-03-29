using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // To teleport player when he reched end of a map
    public Transform playerTrasform;
    public Transform startPoint;

    //Controls
    public FirstPersonLook mouseMovement;
    public FirstPersonMovement capsuleMovement;

    public int Score = 0;

    public TextMeshProUGUI textScore;
    public bool gameStarted = false;
    public bool backInterfaceOnScreen = false;

    public GameObject infoInterface;
    public GameObject backInterface;

    private void Awake()
    {
        Instance = this;
    }

    public void Respawn()
    {
        playerTrasform.position = startPoint.position;
    }

    private void Update()
    {
        textScore.SetText(Score.ToString());
        OnEscape();
    }

    public void OnEscape()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (backInterfaceOnScreen == false)
            {
                Cursor.lockState = CursorLockMode.None;
                // Pause menu become visible
                capsuleMovement.enabled = false;
                //capsule.GetComponent<FirstPersonController>().enabled = false;
                Cursor.visible = true;
                backInterface.SetActive(true);
                backInterfaceOnScreen = true;
                mouseMovement.enabled = false;
            } else
            {
                // Pause menu become invisible
                backInterface.SetActive(false);
                backInterfaceOnScreen = false;
                mouseMovement.enabled = true;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                capsuleMovement.enabled = true;
            }
        }
    }
}
