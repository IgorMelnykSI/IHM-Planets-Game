using UnityEngine;

public class CarStabilizer : MonoBehaviour
{
    public float antiRollForce = 5000f;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 localEulerAngles = transform.localEulerAngles;

        // Check if the car is about to roll over
        if (localEulerAngles.z > 180)
        {
            localEulerAngles.z -= 360;
        }

        if (Mathf.Abs(localEulerAngles.z) > 10f)
        {
            // Apply anti-roll torque to stabilize the car
            float antiRollTorque = Mathf.Clamp(localEulerAngles.z, -1, 1) * -antiRollForce;
            rb.AddTorque(0, 0, antiRollTorque, ForceMode.Force);
        }
    }
}
