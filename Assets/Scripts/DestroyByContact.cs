using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;

    private GameController gameController;

    private void Start() {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if(gameControllerObject != null){
            gameController = gameControllerObject.GetComponent<GameController>();
        }else{
            Debug.Log("Can't find GameController");
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Boundary"){
            return;
        }
        Instantiate(explosion, transform.position, transform.rotation);
        gameController.AddScore(scoreValue);

        if(other.tag == "Player"){
            Instantiate(playerExplosion, transform.position, transform.rotation);
        }
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
