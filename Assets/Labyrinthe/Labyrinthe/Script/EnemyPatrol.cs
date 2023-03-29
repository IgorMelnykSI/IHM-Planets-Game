using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed;
    public Transform[] waypoints;

    public Transform target;
    public int destPoint;
    public int damageInCollision;

    public Transform rotation;
    // Start is called before the first frame update
    void Start()
    {
        target = waypoints[0];
        transform.rotation *= Quaternion.Euler(0, 180, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized*speed*Time.deltaTime,Space.World);
        // Si l'ennemi est quasiment arrivé à sa destination
        if(Vector3.Distance(transform.position, target.position) < 0.3f){
            destPoint = (destPoint + 1) % waypoints.Length;
            target = waypoints[destPoint];
            transform.rotation *= Quaternion.Euler(0, 180, 0);
            
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.transform.CompareTag("Player")){
            PlayerScript playerHealth = other.transform.GetComponent<PlayerScript>();
            playerHealth.TakeDamage(20);
        }
    }

}
