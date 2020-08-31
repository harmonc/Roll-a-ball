using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript : MonoBehaviour
{

    public GameObject otherPortal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        Vector3 difference = other.transform.position - transform.position;
        difference = difference * 2.0f;
        Vector3 rotatedDifference = Quaternion.Euler(0, -transform.rotation.eulerAngles.y, 0) * difference;
        rotatedDifference = Quaternion.Euler(0, otherPortal.transform.rotation.eulerAngles.y, 0) * rotatedDifference;

        other.transform.position = otherPortal.transform.position + rotatedDifference;
        Rigidbody rb = other.GetComponent<Rigidbody>();
        rb.velocity = Quaternion.Euler(0.0f, 180, 0.0f) * rb.velocity;
        rb.velocity = Quaternion.Euler(0.0f, -transform.rotation.eulerAngles.y, 0) * rb.velocity;
        rb.velocity = Quaternion.Euler(0.0f, otherPortal.transform.rotation.eulerAngles.y, 0) * rb.velocity;
    }
}
