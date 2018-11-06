using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadBlockSpawner : MonoBehaviour {

    public GameObject roadBlock;
    public float maxPos = 2f;
    public float delayTimer = 1f;
    float timer;
	// Use this for initialization
	void Start () {
        timer = delayTimer;
	}
	
	// Update is called once per frame
	void Update () {

        timer -= Time.deltaTime;
        if (timer <= 0) {
            //spawn roadblock in random place 
            Vector3 roadBlockPos = new Vector3(Random.Range(-2, 2), transform.position.y, transform.position.z);

            Instantiate(roadBlock, roadBlockPos, transform.rotation);
            timer = delayTimer;
        }

    }
}
