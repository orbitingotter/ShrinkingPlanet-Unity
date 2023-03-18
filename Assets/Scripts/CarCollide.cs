using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCollide : MonoBehaviour
{
    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "Crater")
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }

}
