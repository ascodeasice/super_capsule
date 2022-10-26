using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField]float speedX=0;
    [SerializeField]float speedY=1f;
    [SerializeField]float speedZ=0;


    void Update()
    {
        // rotate every second instead of every frame
        transform.Rotate(360 * speedX*Time.deltaTime, 360 * speedY*Time.deltaTime, 360 * speedZ*Time.deltaTime);
    }
}
