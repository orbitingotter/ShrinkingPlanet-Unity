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

    private GameManager gmRef;
    private PlanetShrink planetRef;
    // android
    private float screenWidth;
    private bool isAndroid;
    private Touch touch;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        gmRef = FindObjectOfType<GameManager>();
        planetRef = FindObjectOfType<PlanetShrink>();

        //android
        if(gmRef.isAndroid)
        {
            isAndroid = true;
            screenWidth = Screen.width;
        }
    }

    void Update()
    {
        if(isAndroid)
        {
            horizontal = 0.0f;

            if(Input.touchCount > 0)
            {
                touch = Input.GetTouch(0);

                if (touch.position.x > screenWidth / 2)
                    horizontal = (touch.position.x - (screenWidth / 2)) / (screenWidth / 2);
                else if (touch.position.x < screenWidth / 2)
                    horizontal = -1.0f + (touch.position.x / (screenWidth / 2));
            }
        }
        else
        {
            horizontal = Input.GetAxisRaw("Horizontal");
        }
    }

    void FixedUpdate()
    {
        transform.RotateAroundLocal(transform.position, horizontal * horizontalSpeed * Time.deltaTime);
        rb.position = rb.position + transform.forward * moveSpeed * Time.fixedDeltaTime;

        // fix - floating player
        if(transform.position.magnitude > planetRef.radius)
        {
            rb.AddForce(transform.TransformDirection(Vector3.down) * 100.0f);
        }
    }
}
