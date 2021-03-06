﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour
{

    [SerializeField] Text highScore = null;

    // ----------------------------------------------- Metode ----------------------- //

    public void Start()
    {
        ShowBestScore();
    }

    public void ShowBestScore()
    {
        if (CompareTag("MainMenu"))
            highScore.text = "BEST SCORE: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        gameObject.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit(); // Functioneaza dupa ce dam build la proiect 
        // Test in editor:
        Debug.Log("Ati parasit jocul!");
    }
}
