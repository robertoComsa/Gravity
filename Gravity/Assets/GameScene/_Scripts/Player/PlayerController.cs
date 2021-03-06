﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // -------------------------------------------------------- Variabile - vizibile in editor ------------------------------------------------------------ //

    [SerializeField] private float playerSpeed = 0f;
    public void SetPlayerSpeed(float value){ playerSpeed = value; }
    public float GetPlayerSpeed{ get { return playerSpeed; } }

    [SerializeField] private PlayerHealth health = null;
    [SerializeField] private GameObject pauseMenu = null;
    List<ParticleSystem> list = new List<ParticleSystem>();
    [SerializeField] ParticleSystem system1 = null; 
    [SerializeField] ParticleSystem system2 = null;

    // ----------------------------------------------------------------- Variabile ---------------------------------------------------------------------- //

    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    int vertical = 0;
    int horizontal = 0;
    bool isPaused = false;
    PlayerAbilitties abilities = null;

    // --------------------------------------------------------------- Metode sistem ------------------------------------------------------------------- //

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        abilities = GetComponent<PlayerAbilitties>();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        ManageMovement();
        ManageBestScore();
        ManagePauseMenu();
    }

    private void FixedUpdate()
    {
        ApplyMovement();
    }

    private void ManagePauseMenu()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                isPaused = true;
                Time.timeScale = 0f;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                pauseMenu.SetActive(true);
            }
            else if(isPaused)
            {
                isPaused = false;
                pauseMenu.GetComponent<MainMenu>().ResumeGame();
            }
        }
    }

    // ------------------------------------------------------------------ Miscare  ------------------------------------------------------------------------- // 

    private void ManageMovement()
    {
        if (Input.GetKey(KeyCode.LeftArrow)) horizontal = -1;
        else if (Input.GetKey(KeyCode.RightArrow)) horizontal = 1;
        else horizontal = 0;

        if (Input.GetKey(KeyCode.UpArrow)) vertical = 1;
        else if (Input.GetKey(KeyCode.DownArrow)) vertical = -1;
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

    public void ManageBestScore()
    {
        if(score > PlayerPrefs.GetInt("HighScore",0))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }

    public void AddScore(int scoreToAdd)
    {
        if (health.IsAlive())
        {
            score += scoreToAdd;
            scoreText.text = score.ToString();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BH")) 
        {
            health.Die();
            list.Add(Instantiate(system2, collision.transform.position, Quaternion.identity));        
            list[list.Count - 1].Play();
        }
        else if (collision.CompareTag("Heart"))
        {
            health.GetHealed();
            list.Add(Instantiate(system1, collision.transform.position, Quaternion.identity));        
            list[list.Count - 1].Play();
            Destroy(collision.gameObject);
           
        }
        else if (collision.CompareTag("Asteroid"))
        {
            list.Add(Instantiate(system2, collision.transform.position, Quaternion.identity));        
            list[list.Count - 1].Play();
            if (abilities.GetIsShieldOn())
                Destroy(collision.gameObject);
            else
            {
                health.TakeDamage();
                AddScore(-scoreForAsteroid);
                Destroy(collision.gameObject);
            }
            
        }
        else if (collision.CompareTag("Satellite") && collision.GetComponent<SpaceObject>().GetSaved == false) // a 2-a conditie necesara pentru a evita exploit de obtinere scor.
            AddScore(scoreForSatellite);
        
        if(list.Count != 0 && (!list[0].isPlaying))
        {
            Destroy(list[0].gameObject);
            list.RemoveAt(0);
        }
    }
}
