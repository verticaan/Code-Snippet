using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CratePushController : MonoBehaviour
{
    public float pushForce = 10f;
    public LayerMask crateLayer;

    private Rigidbody playerRb;
    private bool canPushCrate = true;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float pushInput = Input.GetAxisRaw("Push");

        if (pushInput > 0f && canPushCrate)
        {
            TryPushCrate();
        }
    }

    void TryPushCrate()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 1f, crateLayer))
        {
            Rigidbody crateRb = hit.collider.GetComponent<Rigidbody>();
            if (crateRb != null)
            {
                crateRb.AddForce(transform.forward * pushForce, ForceMode.Impulse);
                canPushCrate = false;
                Invoke("ResetCanPushCrate", 1f); // Wait 1 second before allowing the player to push another crate
            }
        }
    }

    void ResetCanPushCrate()
    {
        canPushCrate = true;
    }
}
