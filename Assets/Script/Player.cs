using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public Player_State_Machine state_machine;
	public Animator anim;
	public Rigidbody2D rb;
	public float move_speed = 20f;
	

	public Player_State state_Idle;
	public Player_State state_Move;
	public Player_State state_Jump;
	


	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		state_machine = new Player_State_Machine();
		state_Idle = new Player_State_Idle(this, state_machine, "Idle");
		state_Move = new Player_State_Move(this, state_machine, "Move");
		state_Jump = new Player_State_Jump(this, state_machine, "Jump");
	}

	private void Start()
	{
		state_machine.Initialize(state_Idle);
	}

	private void Update()
	{
		state_machine.current_state.Update();
	}

	public void Set_Velocity(float _x, float _y)
	{
		rb.velocity = new Vector3(_x, _y);
	}



}
