using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    // Variabile

    int playerHealth = 0;
    [SerializeField] GameObject[] hearts = null;

    // --------------------------------------------------------------- Metode -------------------------------------------------------- //

    private void Awake()
    {
        playerHealth = hearts.Length;
    }

    private void Update()
    {
        if (playerHealth == 0) Die();
    }

    public void TakeDamage()
    {
        playerHealth -= 1;
        hearts[playerHealth].SetActive(false);
    }

    public void GetHealed()
    {
        if (playerHealth < 3)
        {
            hearts[playerHealth].SetActive(true);
            playerHealth += 1; 
        }
    }

    public void Die()
    { 
        Destroy(this.gameObject);
        // + Restart button enabled care va apela metoda de mai jos
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
