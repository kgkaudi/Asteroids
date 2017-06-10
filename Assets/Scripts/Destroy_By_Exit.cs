﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_By_Exit : MonoBehaviour {

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Bolt")
        {
            Destroy(other.gameObject);
        }
    }
}
