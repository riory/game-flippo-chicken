using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PipeSpawnerScript : MonoBehaviour {
    public GameObject pipe;
    public float spawnRateSec = 2;
    private float timer = 0;
    public float heightOffset = 10;
    public float rotationOffsetZ = 10;

    void Start() {
        spawnPipe();
    }

    void Update() {
        if (timer < spawnRateSec) {
            timer += Time.deltaTime;
        } else {
            spawnPipe();
            timer = 0;
        }
    }

    void spawnPipe() {
        var lowestPoint = transform.position.y - heightOffset;
        var highestPoint = transform.position.y + heightOffset;

        var zRotMin = transform.rotation.z - rotationOffsetZ;  
        var zRotMax = transform.rotation.z + rotationOffsetZ;  
        var position = new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0);
        var rotation = Quaternion.AngleAxis(Random.Range(zRotMin, zRotMax), Vector3.forward);
        Instantiate(pipe, position, rotation);
    }
}
