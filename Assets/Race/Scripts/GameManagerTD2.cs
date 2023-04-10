using System.Collections;
using TMPro;
using UnityEngine;

public class GameManagerTD2 : MonoBehaviour
{
    public PlayerControls playerControls;
    public AIControls[] aiControls;
    public LapManager lapTracker;
    public TricolorLights tricolorLights;

    // Sounds
    public AudioSource audioSource;
    public AudioClip lowBeep;
    public AudioClip highBeep;

    private void Awake()
    {
        StartGame();
    }

    public void StartGame()
    {
        FreezePlayers(true);
        StartCoroutine("Countdown");
    }

    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(1);

        Debug.Log("3");
        audioSource.PlayOneShot(lowBeep);
        tricolorLights.SetProgress(1);
        yield return new WaitForSeconds(1);

        Debug.Log("2");
        audioSource.PlayOneShot(lowBeep);
        tricolorLights.SetProgress(2);
        yield return new WaitForSeconds(1);

        Debug.Log("1");
        audioSource.PlayOneShot(lowBeep);
        tricolorLights.SetProgress(3);
        yield return new WaitForSeconds(1);

        Debug.Log("GO");
        tricolorLights.SetProgress(4);
        audioSource.PlayOneShot(highBeep);

        StartRacing();

        yield return new WaitForSeconds(2f);
        tricolorLights.SetAllLightsOff();
    }

    public void StartRacing()
    {
        FreezePlayers(false);
    }

    void FreezePlayers(bool freeze)
    {
        foreach (AIControls aicontrol in aiControls)
        {
            aicontrol.enabled = !freeze;
        }
        playerControls.enabled = !freeze;
    }
}
