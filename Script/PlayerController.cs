using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private CharacterController controller;
	private Vector3 direction;
	public float forwardSpeed;
	public float laneDistance = 2; // distance between each lane
	private int desiredLane = 1;// 0 :left, 1 middle 2: right
	
	
	
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }
	
	// Update is called over and over 
	private void FixedUpdate(){
		controller.Move(direction*Time.fixedDeltaTime);
	}

    // Update is called once per frame
    void Update()
    {
		direction.z = forwardSpeed;
		
		// Gather the inputs on which lane we should be
		if(Input.GetKeyDown(KeyCode.RightArrow)){
			desiredLane ++;
			if(desiredLane == 3) desiredLane = 2;
		}
		if (Input.GetKeyDown(KeyCode.LeftArrow)){
			desiredLane --;
			if(desiredLane == -1) desiredLane = 0;
		}
		// Calculate where we should be in the furture
		Vector3 targetPos = transform.position.z*transform.forward +
							transform.position.y*transform.up;
		if(desiredLane == 0){
			targetPos += Vector3.left*laneDistance;
		}
		else if(desiredLane == 2){
			targetPos += Vector3.right*laneDistance;
		}
		transform.position = targetPos;
    }
}
