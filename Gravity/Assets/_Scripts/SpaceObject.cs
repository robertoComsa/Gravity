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

    // --------------------------------------------------------------- Metode ------------------------------------------------------- //

    private void Awake()
    {
       speed = UnityEngine.Random.Range(minSpeed, maxSpeed);
    }

    void Update()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, blackHole.transform.position, speed * Time.deltaTime);
    }
}
