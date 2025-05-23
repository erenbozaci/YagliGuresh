using UnityEngine;

public class PehlivanGrab3D : MonoBehaviour
{
    public KeyCode grabKey = KeyCode.E;
    public float grabRange = 1.5f;
    public LayerMask rakipLayer;
    public Transform grabPoint;

    private bool isGrabbing = false;
    private GameObject grabbedRakip;

    void Update()
    {
        if (Input.GetKeyDown(grabKey) && !isGrabbing)
        {
            TryGrab();
        }
        else if (Input.GetKeyUp(grabKey) && isGrabbing)
        {
            ReleaseGrab();
        }

        if (isGrabbing && grabbedRakip != null)
        {
            // Rakibi sabit noktada tutar
            grabbedRakip.transform.position = grabPoint.position;
        }
    }

    void TryGrab()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, grabRange, rakipLayer);

        if (hits.Length > 0)
        {
            grabbedRakip = hits[0].gameObject;
            isGrabbing = true;

            Rigidbody rakipRb = grabbedRakip.GetComponent<Rigidbody>();
            if (rakipRb != null)
            {
                rakipRb.velocity = Vector3.zero;
                rakipRb.useGravity = false;
                rakipRb.isKinematic = true; // Rakibi kontrol altýna aldýk
            }

            Debug.Log("RAKÝP 3D KISPETTEN YAKALANDI!");
        }
    }

    void ReleaseGrab()
    {
        if (grabbedRakip != null)
        {
            Rigidbody rakipRb = grabbedRakip.GetComponent<Rigidbody>();
            if (rakipRb != null)
            {
                rakipRb.useGravity = true;
                rakipRb.isKinematic = false;
            }
        }

        isGrabbing = false;
        grabbedRakip = null;

        Debug.Log("TUTUÞ SERBEST BIRAKILDI.");
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, grabRange);
    }
}
