using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerObject : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        // if entering object is tagged as the Player or Bullet
        var tag = collider.gameObject.tag;
        if (tag == "Player" || tag == "Bullet")
        {
            GameManager.Instance.takeDammage();
            Destroy(this.gameObject);
        }
    }
}
