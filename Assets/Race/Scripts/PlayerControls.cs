using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerControls : MonoBehaviour
{
    private Vector2 input;
    public UnityEvent<Vector2> onInput;
    private FlyingDetector flyingDetector;
    public LayerMask groundLayer;
    public float groundedAngularDrag = 0.05f;
    public float flyingAngularDrag = 2f;
    public float groundedDrag = 0.05f;
    public float flyingDrag = 2f;
    public float groundedGravityMultiplier = 1f;
    public float flyingGravityMultiplier = 1.7f;
    public Transform resetPosition;
    private Vector3 initialPosition;
    private Quaternion initialRotation;

    private void Start()
    {
        flyingDetector = GetComponent<FlyingDetector>();
        if (flyingDetector == null)
        {
            Debug.LogError("FlyingDetector script not found on the game object.");
        }
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M)){
            SceneManager.LoadScene("MainScene");

        }
        float inputY = Input.GetAxis("Vertical");
        float inputX = Input.GetAxis("Horizontal");

        Rigidbody rb = GetComponent<Rigidbody>();

        if (flyingDetector != null)
        {
            bool isFlying = flyingDetector.GetIsFlying();

            if (isFlying && Mathf.Abs(rb.velocity.y) > 1.5f)
            {
                input = new Vector2(0, 0).normalized;
                rb.angularDrag = flyingAngularDrag;
                rb.drag = flyingDrag;
                Physics.gravity = new Vector3(0, -9.81f * flyingGravityMultiplier, 0);
                Debug.Log("Flying 2");
            }
            else
            {
                input = new Vector2(inputX, inputY).normalized;
                rb.angularDrag = groundedAngularDrag;
                rb.drag = groundedDrag;
                Physics.gravity = new Vector3(0, -9.81f * groundedGravityMultiplier, 0);
                Debug.Log("Grounded 2");
            }
        }

        if (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Resetting player position");
            ResetPlayerPosition();
        }

        onInput?.Invoke(input);
    }

    public void ResetPlayerPosition()
    {
        transform.position = initialPosition;
        transform.rotation = initialRotation;

        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}
