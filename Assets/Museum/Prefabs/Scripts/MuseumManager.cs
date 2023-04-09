using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuseumManager : MonoBehaviour
{

    public static MuseumManager Instance;

    public GameObject nextInterface;
    public bool playerNearDoor = false;

    public void Awake()
    {
        Instance = this;
    }


    // Update is called once per frame
    void Update()
    {
        // When player is near the door, pop-up will be active
        nextInterface.SetActive(playerNearDoor);
    }
        
}
