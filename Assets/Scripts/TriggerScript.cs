using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        var tag = collider.gameObject.tag;
        if (tag == "Player" || tag == "Bullet")
        {
            GameManager.Instance.gameStarted = true;
        }
    }
}
