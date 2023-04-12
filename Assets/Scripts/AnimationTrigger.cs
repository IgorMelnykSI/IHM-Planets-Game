using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTrigger : MonoBehaviour
{
    public GameObject targetObject;
    public GameObject playAnimationInterface;

    private bool playerIsNear = false;

    void OnTriggerEnter(Collider collider)
    {
        // if entering object is tagged as the Player or Bullet
        var tag = collider.gameObject.tag;
        if (tag == "Player")
        {
            playerIsNear = true;
            playAnimationInterface.SetActive(playerIsNear);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        playerIsNear = false;
        playAnimationInterface.SetActive(playerIsNear);
    }

    private void Update()
    {
        if (playerIsNear)
        {
            OnE();
        }
    }

    private void OnE()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            targetObject.GetComponent<Animator>().SetTrigger("Start");
        }
    }
}
