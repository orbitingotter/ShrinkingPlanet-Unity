using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform target;

    public Vector3 offset;
    public float smoothness;
    public float rotationSmoothness;

    private GameManager gmRef;

    void Start()
    {
        gmRef = FindObjectOfType<GameManager>();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        //transform.position = target.TransformDirection(offset);
        if (!gmRef.gameHasEnded)
        {
            transform.position = Vector3.Lerp(transform.position, target.TransformDirection(offset), smoothness);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(-transform.position, target.forward), rotationSmoothness);
        }
    }
}
