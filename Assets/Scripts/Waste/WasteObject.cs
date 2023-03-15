using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WasteObject : MonoBehaviour
{


    void OnTriggerEnter(Collider collider)
    {
        // if entering object is tagged as the Player or Bullet
        var tag = collider.gameObject.tag;
        if (tag == "Player" || tag == "Bullet")
        {
            GameManager.Instance.Score++;
            this.gameObject.GetComponent<ParticleSystem>().Play();
            Destroy(this.gameObject, 0.3f);
            Debug.Log("Le score actuel est : " + GameManager.Instance.Score);
        }
    }
}
