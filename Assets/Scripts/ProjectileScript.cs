using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        GameObject cam = GameObject.Find("Camera Parent");
        Vector3 movement = new Vector3(0.0f, 0.0f, 1.0f);
        Vector3 rotatedMovementVector = Quaternion.Euler(0, cam.transform.rotation.eulerAngles.y, 0) * movement * speed;
        rb.velocity = rotatedMovementVector;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}

