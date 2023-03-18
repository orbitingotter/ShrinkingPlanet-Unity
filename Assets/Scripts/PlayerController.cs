using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float horizontalSpeed = 1.0f;
    public float smoothness = 0.0f;
    private float horizontal;
    private Rigidbody rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
    }

    void FixedUpdate()
    {
        transform.RotateAroundLocal(transform.position, horizontal * horizontalSpeed * Time.deltaTime);
        Vector3 newPos = rb.position + transform.forward * moveSpeed * Time.fixedDeltaTime;
        rb.position = newPos;
    }
}
