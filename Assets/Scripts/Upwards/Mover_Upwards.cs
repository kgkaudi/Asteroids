using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover_Upwards : MonoBehaviour {

    private float speed;

    void Start()
    {
        speed = Random.Range(1, 10);
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }
}
