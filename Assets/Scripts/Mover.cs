using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float speed;

    void Start()
    {
        Rigidbody laser = GetComponent<Rigidbody>();        
        laser.velocity = transform.forward*speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
