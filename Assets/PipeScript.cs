using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeScript : MonoBehaviour {
    public float moveSpeed = 5.0f;
    public float despawnOffsetX = -45;
    void Start() {

    }
    void Update() {
        transform.position += (Vector3.left * moveSpeed) * Time.deltaTime;
        if (transform.position.x < despawnOffsetX) {
            //Debug.Log("Pipe deleted");
            Destroy(gameObject);
        }
    }
}
