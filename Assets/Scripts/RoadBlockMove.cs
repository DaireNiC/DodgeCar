﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadBlockMove : MonoBehaviour {

    public float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //move the block in the y axiss
        // dont move the block on the x axis, only move in y
        transform.Translate(new Vector3(0,-1,0) * speed * Time.deltaTime);

	}
}
