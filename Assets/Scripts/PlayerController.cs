using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private GameObject focalPoint;
    private float powerUpStrength = 15.0f;
    public float speed = 5.0f;
    public bool hasPowerup;

    // Start is called before the first frame update
    void Start()
    {
       playerRb = GetComponent<Rigidbody>(); 
       focalPoint = GameObject.Find("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");

        playerRb.AddForce(focalPoint.transform.forward * forwardInput * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        hasPowerup = true;
        Destroy(other.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
       if(collision.gameObject.CompareTag("Enemy") && hasPowerup)
       {
          Rigidbody EnemyRigidbody = collision.gameObject.GetComponent<EnemyRigidbody>();
          Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;

          enemyRigidbody.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);
          Debug.Log("Collided with: " + collision.gameObject.name + " with powerup set to " + hasPowerup);
       }
    }
}
