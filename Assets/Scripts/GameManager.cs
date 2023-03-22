using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

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

    private void Update()
    {
        textScore.SetText(Score.ToString());
        OnEscape();
    }

    public void OnEscape()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            if (backInterfaceOnScreen == false)
            {
                backInterface.SetActive(true);
                backInterfaceOnScreen = true;
            } else
            {
                backInterface.SetActive(false);
                backInterfaceOnScreen = false;
            }
        }
    }
}
