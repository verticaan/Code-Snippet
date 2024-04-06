using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverController : MonoBehaviour
{
    public GameObject SpinningDoor;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Quill")
        {
            Destroy(SpinningDoor);
        }
    }
}
