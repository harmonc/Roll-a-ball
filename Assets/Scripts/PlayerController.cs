using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0.0f;
    public TextMeshProUGUI countText;
    public GameObject winText;
    public GameObject blueBullet;
    public GameObject orangeBullet;

    private bool blue = false;
    private GameObject cam;
    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Camera Parent");
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.SetActive(false);
    }

    void SetCountText() {
        countText.text = "Count: " + count.ToString();
        if (count >= 12) {
            winText.SetActive(true);
        }
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void OnFire() {
        if (blue)
        {
            Instantiate(blueBullet, transform.position, transform.rotation);
        }
        else
        {
            Instantiate(orangeBullet, transform.position, transform.rotation);
        }
        blue = !blue;
    }

   
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX,0.0f,movementY);
        Vector3 rotatedMovementVector = Quaternion.Euler(0, cam.transform.rotation.eulerAngles.y, 0) * movement;
        rb.AddForce(rotatedMovementVector * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }
}
