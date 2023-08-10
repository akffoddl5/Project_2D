using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_State_Idle : Player_State_Ground
{
	public Player_State_Idle(Player _player, Player_State_Machine _state_machine, string _anim_bool_name) : base(_player, _state_machine, _anim_bool_name)
	{
	}
	
	public override void Enter()
	{
		base.Enter();
	}

	public override void Exit()
	{
		base.Exit();
	}

	public override void Update()
	{
		base.Update();
		//Debug.Log("idle....");

		if (player.axis_X != 0)
		{
			//Debug.Log("Move change....");
			state_machine.ChangeState(player.state_Move);
		}
	}
}
