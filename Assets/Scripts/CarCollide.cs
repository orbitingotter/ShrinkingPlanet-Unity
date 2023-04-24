using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCollide : MonoBehaviour
{
    public GameObject destroyedCar;
    public GameObject explosionPrefab;


    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "Crater")
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    public void DestroyCar()
    {
        Instantiate(destroyedCar, transform.position, transform.rotation);
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }

}
