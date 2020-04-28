using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    //  -------------------------------------------------------------- Variabile ------------------------------------------------------- //

    int playerHealth = 0;
    bool isAlive = true;
    public bool IsAlive(){ return isAlive; } 

    // ------------------------------------------------------ Variabile vizibile in editor -------------------------------------------//

    [SerializeField] GameObject[] hearts = null;
    [SerializeField] GameObject afterDeathMenu = null;

    // --------------------------------------------------------------- Metode -------------------------------------------------------- //

    private void Awake()
    {
        playerHealth = hearts.Length;
    }

    private void Start()
    {
        isAlive = true;
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
        isAlive = false;
        Destroy(this.gameObject);
        afterDeathMenu.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
