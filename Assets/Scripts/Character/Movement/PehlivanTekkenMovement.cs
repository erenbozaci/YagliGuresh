using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PehlivanTekkenMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody rb;

    private Vector3 movement;

    public Transform rakip;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal"); // A / D ya da Sol – Sað
        movement = new Vector3(horizontal, 0f).normalized; // Yalnýzca X ekseni
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement *moveSpeed * Time.fixedDeltaTime);
    }

    void LateUpdate()
    {
        if (rakip != null)
        {
            Vector3 scale = transform.localScale;
            scale.x = (transform.position.x < rakip.position.x) ? 1f : -1f;
            transform.localScale = scale;
        }
    }
}