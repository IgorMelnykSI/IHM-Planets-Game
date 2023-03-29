using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    private Vector3 initialPosition; // position initiale du personnage

    private void Start()
    {
        initialPosition = transform.position; // stocker la position initiale du personnage
    }

    private void Update()
    {
        // Avancer le personnage de 5 en x
        transform.position += new Vector3(5f * Time.deltaTime, 0f, 0f);

        // Si le personnage a dépassé la position initiale, le ramener à sa position initiale
        if (transform.position.x > initialPosition.x + 5f)
        {
            transform.position = initialPosition;
        }
    }
}
