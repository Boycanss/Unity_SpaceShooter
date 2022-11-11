using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary{
    public float xMin,xMax,zMin,zMax;
}

public class PlayerController : MonoBehaviour
{

    public float speed;
    public Boundary boundary;
    public float tilt;

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;

    private float nextFire;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update(){
        // Input.GetButton()
        // Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        if(Input.GetButton("Fire1") && Time.time > nextFire){
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            GetComponent<AudioSource>().Play();
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Rigidbody player = GetComponent<Rigidbody>();

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        player.velocity = movement*speed;

        player.position = new Vector3(
            Mathf.Clamp(player.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(player.position.z, boundary.zMin, boundary.zMax)
        );

        player.rotation = Quaternion.Euler(0.0f, 0.0f, player.velocity.x * -tilt);
    }
}
