using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public Rigidbody rg;
    public float forwardMoveSpeed = 120f;
    public float backwardMoveSpeed = 60f;
    public float steerSpeed = 250f;

    public Vector2 input;
    public void SetInputs(Vector2 input)
    {
        this.input = input;
    }

    // Apply physics here
    void FixedUpdate()
    {
        float speed = input.y > 0 ? forwardMoveSpeed : backwardMoveSpeed;
        rg.AddForce(input.y * this.transform.forward * speed, ForceMode.Acceleration);
        float rotation = input.x * steerSpeed * Time.fixedDeltaTime * input.y;
        transform.Rotate(0, rotation, 0, Space.World);
    }

    public float GetSpeed()
    {
        return Vector3.Dot(rg.velocity, transform.forward.normalized);
    }
}
