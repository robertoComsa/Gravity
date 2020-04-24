using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // ------------------------------------------------ Variabile - vizibile in editor ---------------------------------------------- //

    [SerializeField] GameObject asteroid = null;
    [SerializeField] GameObject satellite = null; 
    [SerializeField]  PlayerController player = null;
    [SerializeField] float spawnWait = 0f;

    // ------------------------------------------------------------- Metode --------------------------------------------------------- //

    private void Start()
    {
        StartCoroutine(SpawnSpaceObjects());
    }

    IEnumerator SpawnSpaceObjects()
    {
        SpawnSpaceObject();
        yield return new WaitForSeconds(spawnWait);
        StartCoroutine(SpawnSpaceObjects());
    }

    public void SpawnSpaceObject()
    {
        Vector2 spawnZone1 = new Vector2(Random.Range(-10f,10f), Random.Range(6f,9f));
        Vector2 spawnZone2 = new Vector2(Random.Range(-10f, 10f), Random.Range(-6f, -9f));
        Vector2 spawnZone3 = new Vector2(Random.Range(10.5f, 13.5f), Random.Range(-9f, 9f));
        Vector2 spawnZone4 = new Vector2(Random.Range(-13.5f, -10.5f), Random.Range(-9f, 9f));

        int rnd_zone = Random.Range(1, 5); 
        float rnd_object = Random.Range(-1f, 1.01f);

        switch(rnd_zone)
        {
            case 1:
                if (rnd_object < 0)
                    Instantiate(asteroid, spawnZone1, Quaternion.identity);
                else if (rnd_object > 0)
                    Instantiate(satellite, spawnZone1, Quaternion.identity);
                break;
            case 2:
                if (rnd_object < 0)
                    Instantiate(asteroid, spawnZone2, Quaternion.identity);
                else if (rnd_object > 0)
                    Instantiate(satellite, spawnZone3, Quaternion.identity);
                break;
            case 3:
                if (rnd_object < 0)
                    Instantiate(asteroid, spawnZone3, Quaternion.identity);
                else if (rnd_object > 0)
                    Instantiate(satellite, spawnZone3, Quaternion.identity);
                break;
            case 4:
                if (rnd_object < 0)
                    Instantiate(asteroid, spawnZone4, Quaternion.identity);
                else if (rnd_object > 0)
                    Instantiate(satellite, spawnZone4, Quaternion.identity);
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Satellite")
        {
            player.AddScore(2*-player.ScoreForSatellite);
            Destroy(collision.gameObject);
        }
        else if(collision.tag == "Asteroid")
        {
            Destroy(collision.gameObject);
        }
    }
}
