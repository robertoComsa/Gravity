using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{
    // Variabile
    
    private Vector2 screenBounds;

    [SerializeField] private Camera mainCamera = null;
    [SerializeField] private float objectWidth = 0f;
    [SerializeField] private float objectHeight = 0f;

    // Metode
    void Start()
    {
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z)); 
    }

    void LateUpdate()
    {
        Vector3 correctPos = transform.position;
    
        correctPos.x = Mathf.Clamp(correctPos.x, screenBounds.x * -1 + objectWidth, screenBounds.x - objectWidth);
        correctPos.y = Mathf.Clamp(correctPos.y, screenBounds.y * -1 + objectHeight, screenBounds.y - objectHeight);

        transform.position = correctPos;
    }
}
