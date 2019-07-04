using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class AttractionForce : MonoBehaviour
{
    public float ForceMagnitude = 500f;

    private Vector3 target = Vector3.zero;
    private Rigidbody rb = null;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rb.AddForce(this.transform.localPosition * -ForceMagnitude * Time.fixedDeltaTime);
    }
}
