using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityAttractor : MonoBehaviour
{
    public float gravity = -10.0f;


    private Vector3 gravityUp;
    private Vector3 bodyUp;
    private Quaternion targetRotation;
    public void Attract(Transform body)
    {
        // gravity
        gravityUp = (body.position - transform.position).normalized;

        body.GetComponent<Rigidbody>().AddForce(gravity * gravityUp);

        // rotation
        bodyUp = body.up;

        targetRotation = Quaternion.FromToRotation(bodyUp, gravityUp) * body.rotation;
        body.rotation = Quaternion.Slerp(body.rotation, targetRotation, 50f * Time.deltaTime);

    }
}
