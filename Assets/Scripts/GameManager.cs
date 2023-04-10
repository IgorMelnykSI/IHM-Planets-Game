using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // To teleport player when he reched end of a map
    public Transform playerTrasform;
    public Transform startPoint;

    //Life
    public List<GameObject> lifeImages;
    private int lifePoints = 3;

    //Controls
    public GameObject player;

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

    public void takeDammage()
    {
        lifeImages[lifePoints - 1].SetActive(false);
        this.lifePoints--;
        if (lifePoints == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void OnEscape()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (backInterfaceOnScreen == false)
            {
                Cursor.lockState = CursorLockMode.None;
                player.SetActive(false);
                Cursor.visible = true;
                backInterface.SetActive(true);
                backInterfaceOnScreen = true;
            } else
            {
                player.SetActive(true);
                // Pause menu become invisible
                backInterface.SetActive(false);
                backInterfaceOnScreen = false;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }
}
