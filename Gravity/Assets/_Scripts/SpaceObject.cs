using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceObject : MonoBehaviour
{
    // ------------------------------------------------- Variabile - vizibile in editor ------------------------------------------ //

    [SerializeField] GameObject blackHole = null;
    [SerializeField] float minSpeed = 0f;
    [SerializeField] float maxSpeed = 0f;

    // ------------------------------------------------------------ Variabile ---------------------------------------------------- //

    float speed = 0f;
    Vector3 destination = Vector3.zero;
    Vector3 initialDestination = Vector3.zero;
    Vector3 newDestination = Vector3.zero;

    // --------------------------------------------------------------- Metode ------------------------------------------------------- //

    private void Awake()
    {
       speed = UnityEngine.Random.Range(minSpeed, maxSpeed);
       initialDestination = blackHole.transform.position; ;
       destination = initialDestination;
       newDestination = transform.position; // Locul in care obiectul s-a instantiat 
    }

    void Update()
    {
        MoveObject(destination);
        ClearSatelliteFromScene();
    }

    private void MoveObject(Vector3 desiredPosition)
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, desiredPosition, speed * Time.deltaTime);
    }

    void ClearSatelliteFromScene()
    {
        if (transform.position == newDestination) Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (tag == "Satellite" && collision.tag == "Player" && destination != newDestination)
            if (Vector3.Distance(collision.gameObject.transform.position, initialDestination) < Vector3.Distance(transform.position, initialDestination))
            {
                destination = newDestination;
                collision.GetComponent<PlayerController>().AddScore(collision.GetComponent<PlayerController>().GetScoreForSatellite);
            }
    }
}
