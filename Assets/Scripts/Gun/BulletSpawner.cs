using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletOrigin;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Pressed primary button.");
            Instantiate(bullet, bulletOrigin.transform.position, bulletOrigin.transform.rotation);
            Debug.Log("Bullet origin : " + bulletOrigin.transform);
        }
            

        if (Input.GetMouseButtonDown(1))
            Debug.Log("Pressed secondary button.");

        if (Input.GetMouseButtonDown(2))
            Debug.Log("Pressed middle click.");
    }

}
