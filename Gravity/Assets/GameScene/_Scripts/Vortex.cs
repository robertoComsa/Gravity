using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vortex : MonoBehaviour
{
    [SerializeField] private int spinSpeed = 10;
    [SerializeField] private bool spinDirection = true;
    [SerializeField] private float size = 0.3f;
    void Update () {
        transform.localScale = new Vector3(size, size,0);
        if(spinDirection == true){
            transform.Rotate(0, 0, spinSpeed * Time.deltaTime);}
        else if(spinDirection == false){
            transform.Rotate(0, 0, (-1)*spinSpeed * Time.deltaTime);}

    }   
}