using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speed = 10.0f;
    public float sensitivity = 1.0f;
    public float maxYAngle = 80.0f;

    private Vector3 movement = Vector3.zero;
    private float rotationX = 0.0f;
    private float rotationY = 0.0f;

    void Update()
    {
        // Rotation de la caméra en fonction de la souris
        // rotationX += Input.GetAxis("Mouse X") * sensitivity;
        // rotationY += Input.GetAxis("Mouse Y") * sensitivity;
        // rotationY = Mathf.Clamp(rotationY, -maxYAngle, maxYAngle);

        transform.localRotation = Quaternion.Euler(-rotationY, rotationX, 0.0f);

        // Déplacement de la caméra en fonction des touches du clavier
        movement = Vector3.zero;

        if (Input.GetKey(KeyCode.Z))
        {
            movement += transform.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            movement -= transform.forward;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            movement -= transform.right;
        }
        if (Input.GetKey(KeyCode.D))
        {
            movement += transform.right;
        }

        movement.Normalize();
        transform.position += movement * speed * Time.deltaTime;
    }
}
