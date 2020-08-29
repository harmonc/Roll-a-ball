using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 10.0f;

    private Vector3 rotatedMovementVector;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        GameObject cam = GameObject.Find("Camera Parent");
        Vector3 movement = new Vector3(0.0f, 0.0f, 1.0f);
        rotatedMovementVector = Quaternion.Euler(0, cam.transform.rotation.eulerAngles.y, 0) * movement * speed;
        rb.velocity = rotatedMovementVector;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("East West Wall") || other.gameObject.CompareTag("North South Wall"))
        {
            GameObject portal = GameObject.Find("Blue Portal");
            if (other.gameObject.CompareTag("East West Wall"))
            {
                float dir = -1.0f;
                float newY = 180.0f;
                if (rotatedMovementVector.x < 0.0f)
                {
                    dir = 1.0f;
                    newY = 0.0f;
                }
                Vector3 newPosition = new Vector3(other.transform.position.x + 0.3f * dir,portal.transform.position.y,transform.position.z);
                portal.transform.position = newPosition;
                portal.transform.localRotation = Quaternion.Euler(0.0f,newY,0.0f);
            }


            Destroy(gameObject);
        }
    }
}

