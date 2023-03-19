using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityAttractor : MonoBehaviour
{
    public float gravity = -10.0f;

    public void Attract(Transform body)
    {
        // gravity
        Vector3 gravityUp = (body.position - transform.position).normalized;

        body.GetComponent<Rigidbody>().AddForce(gravity * gravityUp);

        // rotation
        Vector3 bodyUp = body.up;

        Quaternion targetRotation = Quaternion.FromToRotation(bodyUp, gravityUp) * body.rotation;
        body.rotation = Quaternion.Slerp(body.rotation, targetRotation, 50f * Time.deltaTime);

    }
}
