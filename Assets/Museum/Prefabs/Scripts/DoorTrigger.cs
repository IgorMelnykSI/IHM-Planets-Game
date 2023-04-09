using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorTrigger : MonoBehaviour
{

    void OnTriggerEnter(Collider collider)
    {
        var tag = collider.gameObject.tag;
        if (tag == "Player")
        {
            MuseumManager.Instance.playerNearDoor = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var tag = other.gameObject.tag;
        if (tag == "Player")
        {
            MuseumManager.Instance.playerNearDoor = false;
        }
    }

    private void OnE()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("MainScene"); // TODO Mettre la scene suivante course ou labyrinthe 
        }
    }

    private void Update()
    {
        if (MuseumManager.Instance.playerNearDoor)
        {
            OnE();
        }
    }

}
