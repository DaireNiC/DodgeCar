using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {
    //determines how fast the car moves on the x axis
    public float playerSpeed;
    public float maxPos = 2;
    Vector3 position;
    public UIManager ui;
    public MoveTrack moveTrack;
    public RoadBlockSpawner spawner;
    // Use this for initialization
    void Start () {
        // start position of the player
        position = transform.position;
        
	}
	
	// Update is called once per frame
	void Update () {
        // increase the position on x axis with user input
        position.x += Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime;
      //  position.y += Input.GetAxis("Vertical") * (playerSpeed - 3) * Time.deltaTime;
        //prevents the user from going off the road
        //clamps to the max/min allowed position of x
        position.x = Mathf.Clamp(position.x, -maxPos, maxPos);
        // assign new position to car's object
        transform.position = position;




    }

    void FixedUpdate()
    {
        //steeringAmount = -Input.GetAxis("Horizontal");
        //speed = Input.GetAxis("Vertical") + accelerationPower;
        //direction = Mathf.Sign(Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.up)));
        //rb.rotation += steeringAmount * steeringPower * rb.velocity.magnitude * direction;

        //rb.AddRelativeForce(Vector2.up * speed);
        //rb.AddRelativeForce(-Vector2.right * rb.velocity.magnitude * steeringAmount / 2);

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "RoadBlock")
        {
            //   collision.gameObject.GetComponent<Rigidbody2D>().AddForceAtPosition;
         
            StartCoroutine( ExecuteAfterTime(2));


        }
    }
    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        spawner.spawn = false; //stop spawning roadblocks


        yield return new WaitForSeconds(time);
        moveTrack.speed = 0;
        yield return new WaitForSeconds(time);
        // Code to execute after the delay
        Destroy(gameObject);
        Debug.Log(gameObject.ToString());
        ui.gameOver();
    }

}
