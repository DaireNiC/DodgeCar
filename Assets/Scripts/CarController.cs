using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {
    //determines how fast the car moves on the x axis
    public float playerSpeed;
    public float maxPos = 2;
    Vector3 position;

    Rigidbody2D rb;

    public UIManager ui;
	// Use this for initialization
	void Start () {
        // start position of the player
        position = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        // increase the position on x axis with user input
        position.x += Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime;
        position.y += Input.GetAxis("Vertical") * (playerSpeed - 3)* Time.deltaTime;
        //prevents the user from going off the road
        //clamps to the max/min allowed position of x
        position.x = Mathf.Clamp(position.x, -maxPos, maxPos);
        // assign new position to car's object
        transform.position = position;


	}
     void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "RoadBlock")
        {
            Destroy(gameObject);
            ui.gameOver();
        }
    }
   
}
