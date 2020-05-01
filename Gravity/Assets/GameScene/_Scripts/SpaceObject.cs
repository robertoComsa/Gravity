using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceObject : MonoBehaviour
{
    [SerializeField] PlayerAbilitties player = null;
    // ------------------------------------------------- Variabile - vizibile in editor ------------------------------------------ //

    [SerializeField] GameObject blackHole = null;
    [SerializeField] float minSpeed = 0f;
    [SerializeField] float maxSpeed = 0f;

    // ------------------------------------------------------------ Variabile ---------------------------------------------------- //

    Vector3 destination = Vector3.zero;
    public void SetDestination(Vector3 newDestination) { destination = newDestination; } // Folosita in ultimata playerului

    Vector3 newDestination = Vector3.zero;
    public Vector3 GetSatelliteReturnDestination() { return newDestination; } // In awake newDestination primeste pozitia unde satelitul se intoarce cand e salvat
                                                                              // Folosita in ultimata playerului

    Vector3 initialDestination = Vector3.zero;
    
    bool saved = false;
    public bool GetSaved { get { return saved; } }
    float speed = 0f;

    // ------------------------------------------------------- Metode Sistem --------------------------------------------------------------- //

    private void Awake()
    {
       speed = Random.Range(minSpeed, maxSpeed);

       initialDestination = blackHole.transform.position; ;
       destination = initialDestination;
       newDestination = transform.position; // Locul in care obiectul s-a instantiat 

       player = FindObjectOfType<PlayerAbilitties>();
    }

    void Update()
    {
        MoveObject(destination);
        ClearSatelliteFromScene();
    }

    // -------------------------------------------------------------- Metode --------------------------------------------------------------- //

    private void MoveObject(Vector3 desiredPosition)
    {
        if (player.GetIsMagnetOn() && CompareTag("Heart"))
            transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, 2*speed * Time.deltaTime);
        else
            transform.position = Vector3.MoveTowards(this.transform.position, desiredPosition, speed * Time.deltaTime);
    }

    void ClearSatelliteFromScene()
    {
        if (transform.position == newDestination) Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (CompareTag("Satellite") && collision.CompareTag("Player") && destination != newDestination)
            if (Vector3.Distance(collision.gameObject.transform.position, initialDestination) < Vector3.Distance(transform.position, initialDestination))
            {
                saved = true;
                destination = newDestination;
                collision.GetComponent<PlayerController>().AddScore(collision.GetComponent<PlayerController>().GetScoreForSatellite);
            }
    }
}
