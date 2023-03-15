using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPhysics : MonoBehaviour
{

    public float launchVelocity = 700f;

    void Start()
    {
        Destroy(this.gameObject, 5);

        this.gameObject.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, launchVelocity, 0));
    }

}
