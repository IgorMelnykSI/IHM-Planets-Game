using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public Vector3 marginFromPlayer;

    void Update()
    {
        transform.position = player.transform.position + marginFromPlayer;
        transform.rotation = player.transform.rotation;
    }
}
