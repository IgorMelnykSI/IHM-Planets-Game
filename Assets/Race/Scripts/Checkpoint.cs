using UnityEngine;
using UnityEngine.Events;

public class Checkpoint : MonoBehaviour
{
    public UnityEvent<CarIdentity, Checkpoint> onCheckpointEnter;

    void OnTriggerEnter(Collider collider)
    {
        CarIdentity car = collider.gameObject.GetComponent<CarIdentity>();
        if (car != null)
        {
            onCheckpointEnter.Invoke(car, this);
        }
    }
}
