using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private Transform target;
    private float trackingSpeed;

    public void SetTarget(Transform target, float trackingSpeed)
    {
        this.target = target;
        this.trackingSpeed = trackingSpeed;
    }

    void FixedUpdate()
    {
        if (target != null)
        {
            Vector2 direction = (target.position - transform.position).normalized;

            GetComponent<Rigidbody2D>().velocity = direction * trackingSpeed;
        }
    }
}

