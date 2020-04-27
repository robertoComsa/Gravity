using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // ------------------------------------------------ Variabile - vizibile in editor ---------------------------------------------- //

    [SerializeField] GameObject asteroid = null;
    [SerializeField] GameObject satellite = null;
    [SerializeField] GameObject heart = null;
    [SerializeField] PlayerController player = null;
    [SerializeField] float spawnWait = 0f;

    // ------------------------------------------------------------- Metode --------------------------------------------------------- //

    private void Start()
    {
        StartCoroutine(SpawnSpaceObjects());
        StartCoroutine(DecreaseSpawnWait());
    }

    IEnumerator DecreaseSpawnWait()
    {
        DecreaseSpawnWait();
        yield return new WaitForSeconds(10);
        if (spawnWait > 0.4) spawnWait -= 0.1f;   //  Debug.Log(spawnWait);
        StartCoroutine(DecreaseSpawnWait());
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
                ChooseAndSpawnObj(rnd_object,spawnZone1);
                break;
            case 2:
                ChooseAndSpawnObj(rnd_object, spawnZone2);
                break;
            case 3:
                ChooseAndSpawnObj(rnd_object, spawnZone3);
                break;
            case 4:
                ChooseAndSpawnObj(rnd_object, spawnZone4);
                break;
        }
    }

    private void ChooseAndSpawnObj(float rnd_obj , Vector2 position)
    {
        float rnd2 = Random.Range(-1f, 0.21f);
        if (rnd_obj < 0 && rnd2 < 0) Instantiate(asteroid, position, Quaternion.identity);
        else if (rnd_obj > 0 && rnd2 < 0) Instantiate(satellite, position, Quaternion.identity);
        else if (rnd2 > 0) Instantiate(heart, position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Satellite")
        {
            player.AddScore(2 * -player.GetScoreForSatellite);
            Destroy(collision.gameObject);
        }
        else if (collision.tag == "Asteroid" || collision.tag =="Heart")
        {
            Destroy(collision.gameObject);
        }
    }
}
