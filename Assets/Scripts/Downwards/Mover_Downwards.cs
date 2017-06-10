using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover_Downwards : MonoBehaviour {

    public float speed;

    public void Start()
    {
        speed = Random.Range(-1, -10);
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }
}
