using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_By_Contact_Big_Upwards : MonoBehaviour {

    public GameObject explosion;
    public GameObject playerExplosion;
    public GameObject hazard;
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
            Vector3 spawnPosition = transform.position + new Vector3(0.0f, 0.0f, -27.5f);
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(hazardOrigin, spawnPosition, spawnRotation);
            Destroy(gameObject);
        }
        if (other.tag == "Asteroid")
        {
            Vector3 spawnPosition1 = transform.position + new Vector3(1.0f, 0.0f, 0.0f);
            Vector3 spawnPosition2 = transform.position + new Vector3(-1.0f, 0.0f, 0.0f);
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(other.gameObject);
            Destroy(gameObject);
            Instantiate(hazard, spawnPosition1, spawnRotation);
            Instantiate(hazard, spawnPosition2, spawnRotation);
        }
        if (other.tag == "Bolt")
        {
            gameController.AddScore(scoreValue);
            Vector3 spawnPosition1 = transform.position + new Vector3(1.0f, 0.0f, 0.0f);
            Vector3 spawnPosition2 = transform.position + new Vector3(-1.0f, 0.0f, 0.0f);
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(other.gameObject);
            Destroy(gameObject);
            Instantiate(hazard, spawnPosition1, spawnRotation);
            Instantiate(hazard, spawnPosition2, spawnRotation);
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
