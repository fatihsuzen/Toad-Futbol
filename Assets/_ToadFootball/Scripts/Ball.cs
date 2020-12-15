// Ball.js : Description : this script manage the ball (sound, collision, trail)
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
	private Rigidbody 			rb;									// Ball RigidBody Component
	private TrailRenderer 		trail;								// Ball TrailRenderer Component
	[Header ("The maximum speed of the ball")]
	public float 				maxSpeed = 25;						// change the ball Max speed on table. If you change the cabinet scale you probably must increase the Max speed

	[Header ("Trail")]														
	public float 				Speed_To_Activate_Trail = .5f;		// The Trail become active when ball speed is superior to Speed_To_Activate_Trail
	private bool 				b_trail = true;

	private Vector3 			tmp_vel;							// Used with the function Ball_Pause()

	[Header ("Roll Sound")]	
	private AudioSource 		roll_audio	;						// roll AudioSource Component
	private bool 				once = false;						// Boolean used to play roll sound only if the sound is not playing
	public float 				min_Mag_roll_audio = 1;				// The minimum speed to play the roll sound
	private float 				tmp_Save_Min_Mag = 0;

	public bool 				b_Shake = false;
	public float 				Shake_Force = 2;

	private bool 				b_OnHole = false;					// Use to know if ball is on a hole or not


	void Start() {													// --> function Start			
		rb = GetComponent<Rigidbody>();                                 // Access <Rigidbody>() Component;	
		Physics.gravity = new Vector3(0, -100.8f, 0);
		trail = GetComponent<TrailRenderer>();                          // Access <TrailRenderer>() Component;	

		

		roll_audio = GetComponent<AudioSource>();						// Access <AudioSource>() Component; if roll sound is selected on the inspector

	}

	public void Ball_Shake(Vector3 Direction){
		if(rb)rb.AddForce(Direction*Shake_Force, ForceMode.VelocityChange);	
	}


	void FixedUpdate()															// --> Fixed Update : FixedUpdate is used to deal with Physics
	{
		if(rb.velocity.magnitude > maxSpeed)										// Limit ball speed.
		{
			rb.velocity 			
			= rb.velocity.normalized * maxSpeed;
		}
		if (rb.velocity.magnitude < 20 && CounterController.isStart)                                       // Limit ball speed.
		{
			rb.velocity
			= rb.velocity.normalized * 20;
		}

		if (!once && tmp_Save_Min_Mag == 0){
			roll_audio.pitch = rb.velocity.magnitude/2.5f;							// When ball accelerate the pitch increase. 
		}

	}


	public void Ball_Pause(){													// --> Function Call When the game is on pause
		if(!b_OnHole){
			if(!rb.isKinematic){													// Start Pause
				tmp_vel = rb.velocity;
				rb.isKinematic = true;
			}
			else{																	// Stop Pause
				rb.isKinematic = false;
				rb.velocity = tmp_vel;
			}	
		}	
	}

	public void OnHole(){														// --> Know if ball is on a hole. Prevent bug when a ball enter a hole and player press pause.
		b_OnHole = true;
	}

	public void OutsideHole(){															
		b_OnHole = false;
	}
	public void StartGame()
    {
		int Rnd = Random.Range(0, 2);
		int RndX = Random.Range(-1, -3);
		int RndZ = Random.Range(-5, 5);
		if (Rnd % 2 == 0)
		{
			RndX *= -1;
		}

		if (RndZ == 0)
		{
			RndZ = Random.Range(-5, 5);

			if (RndZ == 0)
			{
				RndZ = Random.Range(-5, 5);
			}
		}

		if (RndX == 0)
		{
			RndX = Random.Range(-10, 10);

			if (RndX == 0)
			{
				RndX = Random.Range(-10, 10);
			}
		}
		rb.AddForce(new Vector3(RndX, 0.4999999f, RndZ) * 100);
	}
}
