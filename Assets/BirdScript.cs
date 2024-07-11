using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour {
    public Rigidbody2D birdRigidbody2D;
    public float flapStrength;
    public LogicScript logic;
    public AudioSource asFlap;
    public bool birdIsAlive = true;
    void Start() {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space) == true && birdIsAlive ) {
            birdRigidbody2D.velocity = Vector2.up * flapStrength;
            asFlap.Play();
        }
        if (transform.position.y < -20 || transform.position.y > 20) {
            logic.gameOver();
            birdIsAlive = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        logic.gameOver();
        birdIsAlive = false;
    }
}
