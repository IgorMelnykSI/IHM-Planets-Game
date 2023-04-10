using System.Collections;
using UnityEngine;

public class GameManagerTD3 : MonoBehaviour
{
    public Animator cameraIntroAnimator;
    public TransformFollower followPlayerCamera;

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
        StartIntro();
    }

    public void StartIntro()
    {
        followPlayerCamera.enabled = false;
        cameraIntroAnimator.enabled = true;
        FreezePlayers(true);
    }

    public void StartCountdown()
    {
        followPlayerCamera.enabled = true;
        cameraIntroAnimator.enabled = false;
        StartCoroutine("Countdown");
    }

    public void StartRacing()
    {
        FreezePlayers(false);
    }

    IEnumerator Countdown()
    {
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

    void FreezePlayers(bool freeze)
    {
        foreach (AIControls aicontrol in aiControls)
        {
            aicontrol.enabled = !freeze;
        }
        playerControls.enabled = !freeze;
    }
}
