using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class CameraController : MonoBehaviour
{
    public GameObject player;

    private Vector3 offset;
    private float x;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    void OnLook(InputValue rotateValue)
    {
        Vector2 rotateVector = rotateValue.Get<Vector2>();
        x = rotateVector.x;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.Rotate(new Vector3(0, x, 0));
        transform.position = player.transform.position + offset;
    }
}