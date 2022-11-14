using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float moveSpeed = 2.0f;
    public Camera camera;

    void Update()
    {
        Vector3 horizontal = camera.transform.right * Input.GetAxis("Horizontal") * moveSpeed;
        Vector3 forward = camera.transform.forward * Input.GetAxis("Vertical") * moveSpeed;
        forward.y = 0;
        rb.velocity = horizontal + forward;
    }
}
