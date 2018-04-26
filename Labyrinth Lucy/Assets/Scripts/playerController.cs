using UnityEngine;

public class playerController : MonoBehaviour {

    private Rigidbody rb;

    public float Speed = 7.0f;

    public LayerMask groundLayers;

    public float jumpForce = 4.0f;

    public CapsuleCollider col;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();
    }

    void FixedUpdate()
    {
        float translation = Input.GetAxis("Vertical") * Speed;
        float strafe = Input.GetAxis("Horizontal") * Speed;
        translation *= Time.deltaTime;
        strafe *= Time.deltaTime;

        transform.Translate(strafe, 0, translation);

        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private bool isGrounded()
    {
        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x, col.bounds.min.y, col.bounds.center.z), col.radius * .9f, groundLayers);
    }

}
