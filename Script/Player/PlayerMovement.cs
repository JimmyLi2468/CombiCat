using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using SkillzSDK;


public class PlayerMovement : MonoBehaviour
{
	
	bool alive = true;
	
	public float speed = 5;
	[SerializeField] Rigidbody rb;
	
	//private int horizontalInput = 1;
	public float lanepos = 1;
	public float horizontalMultiplier = 2;
	
	public float speedIncreasePerPoint = 0.1f;
	
	[SerializeField] float jumpForce = 400f;
	[SerializeField] LayerMask groundMask;
	
	private int flag = 0;
	
	//move the player
	
	
	private void FixedUpdate(){
		
		if(!alive) return;
		
		Vector3 forwardMove = transform.forward*speed*Time.fixedDeltaTime; //direction * speed *unit time(5unit every second)
		//Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime *horizontalMultiplier;
		//rb.MovePosition(rb.position+forwardMove + horizontalMove);
		rb.MovePosition(rb.position+forwardMove);
	}
    

    // Update is called once per frame
    void Update()
    {
        //horizontalInput = Input.GetAxis("Horizontal");
		
		Vector3 pos = new Vector3(transform.position.x, transform.position.y , transform.position.z);
		
		if(SwipeManager.swipeRight)
		{
			if(transform.position.x +3f < 5){
				pos = new Vector3(transform.position.x+ 3f , transform.position.y , transform.position.z );
			}
           
		   flag ++;
		}
 
		if (SwipeManager.swipeLeft)
		{
			if(transform.position.x -3f >-5 ){
				pos = new Vector3(transform.position.x- 3f , transform.position.y , transform.position.z );
			}
			
			flag ++;
		}
		
		transform.position = Vector3.Lerp(transform.position, pos, lanepos);
		/*
		if(flag != 0){
			print("left/right key pressed new x position: "+transform.position.x);
			//print(Time.deltaTime);
			flag = 0;
		}
		*/
		
		if(SwipeManager.swipeUp){
			Jump();
		}
		
		if (transform.position.y < -5){
			Die();
		}
    }
	
	public void Die(){
		alive = false;
		// Restart the game
		//transform.position = new Vector3(0,0,5);
		Invoke("Restart", 2);
	}
	void Restart(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
	
	void Jump(){
		//Check whether we are currently grounded
		float height = GetComponent<Collider>().bounds.size.y;
		bool isGrounded = Physics.Raycast(transform.position, Vector3.down, (height/2)+0.1f, groundMask);
		
		//If we are, jump
		if(isGrounded){
			rb.AddForce(Vector3.up * jumpForce);
			
		}
		
	}
}
