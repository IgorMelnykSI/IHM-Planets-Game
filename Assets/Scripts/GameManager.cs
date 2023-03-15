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

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        textScore.SetText(Score.ToString());
    }
}
