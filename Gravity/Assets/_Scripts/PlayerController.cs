using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // -------------------------------------------------------- Variabile - vizibile in editor ------------------------------------------------------------ //

    [SerializeField] private float playerSpeed = 0f;
    [SerializeField] private PlayerHealth health = null;

    // ----------------------------------------------------------------- Variabile ---------------------------------------------------------------------- //

    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    int vertical = 0;
    int horizontal = 0;

    // --------------------------------------------------------------- Metode sistem ------------------------------------------------------------------- //

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        ManageMovement();
    }

    private void FixedUpdate()
    {
        ApplyMovement();
    }

    // ------------------------------------------------------------------ Miscare  ------------------------------------------------------------------------- // 

    private void ManageMovement()
    {
        if (Input.GetKey("a")) horizontal = -1;
        else if (Input.GetKey("d")) horizontal = 1;
        else horizontal = 0;

        if (Input.GetKey("w")) vertical = 1;
        else if (Input.GetKey("s")) vertical = -1;
        else vertical = 0;

        Vector2 moveInput = new Vector2(horizontal, vertical);
        moveVelocity = moveInput.normalized * playerSpeed; // Normalizam pentru ca altfel pe diagonala ( eg : apasare w si a simultan ) ar avea viteza dubla
    }

    private void ApplyMovement()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }

    // --------------------------------------------------------------- Manager viata & scor ----------------------------------------------------------- //

    [SerializeField] Text scoreText = null;
    [SerializeField] int scoreForSatellite = 0;
    public int GetScoreForSatellite { get { return scoreForSatellite; } }
    [SerializeField] int scoreForAsteroid = 0;
    [SerializeField] int score = 0;
    public int GetScore { get { return score; } }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score : " + score.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "BH") health.Die();
        else if (collision.tag == "Asteroid")
        {
            health.TakeDamage();
            AddScore(-scoreForAsteroid);
            Destroy(collision.gameObject);
        }
        else if(collision.tag == "Satellite" && collision.GetComponent<SpaceObject>().GetSaved == false) // a 2-a conditie necesara pentru a evita exploit de obtinere scor.
            AddScore(scoreForSatellite);
    }


    // ------------------------------------------------------------------ ABILITATI ------------------------------------------------------------------------ //
}
