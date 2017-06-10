using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_By_Contact : MonoBehaviour {

    public GameObject explosion;
    public GameObject playerExplosion;
    public GameObject hazardOrigin;
    public int scoreValue;
    private Game_Controller gameController;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<Game_Controller>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
        {
            Vector3 spawnPosition = transform.position + new Vector3(0.0f, 0.0f, 27.5f);
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(hazardOrigin, spawnPosition, spawnRotation);
            Destroy(gameObject);
        }
        if (other.tag == "Asteroid")
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        if (other.tag == "Bolt")
        {
            gameController.AddScore(scoreValue);
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
