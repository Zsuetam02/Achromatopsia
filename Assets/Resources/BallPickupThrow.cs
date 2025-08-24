using UnityEngine;

public class BallPickupThrow : MonoBehaviour
{
    public float pickupRange = 8f;
    public float throwForce = 15f;
    public Transform holdPoint; 

    public GameObject heldBall = null;
    private Rigidbody heldRb = null;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (heldBall == null)
            {
                TryPickupBall();
            }
            else
            {
                ThrowBall();
            }
        }

        if (heldBall != null)
        {
            heldBall.transform.position = Vector3.Lerp(
                heldBall.transform.position,
                holdPoint.position,
                Time.deltaTime * 10f
            );
        }
    }

    void TryPickupBall()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        string[] validTags = { "P1", "P2", "P3", "P4", "P5", "P6", "P7", "P8" };

        if (Physics.Raycast(ray, out RaycastHit hit, pickupRange))
        {
            if (hit.collider.name == "Ball(Clone)" && System.Array.Exists(validTags, tag => hit.collider.CompareTag(tag)))
            {
                heldBall = hit.collider.gameObject;
                heldRb = heldBall.GetComponent<Rigidbody>();

                var creep = heldBall.GetComponent<CreepToCenter>();
                if (creep != null)
                    creep.SetHeld(true);

                if (heldRb != null)
                {
                    heldRb.useGravity = false;
                    heldRb.velocity = Vector3.zero;
                    heldRb.angularVelocity = Vector3.zero;
                    heldRb.freezeRotation = true;
                }
            }
        }
    }

    void ThrowBall()
    {
        if (heldBall != null)
        {
            var creep = heldBall.GetComponent<CreepToCenter>();
            if (creep != null)
                creep.SetHeld(false);
        }

        if (heldRb != null)
        {
            heldRb.useGravity = true;
            heldRb.freezeRotation = false;
            heldRb.AddForce(Camera.main.transform.forward * throwForce, ForceMode.Impulse);
        }

        heldBall = null;
        heldRb = null;
    }
}