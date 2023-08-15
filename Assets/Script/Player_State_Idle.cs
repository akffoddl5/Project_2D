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
		player.rb.velocity = Vector2.zero;
		
	}

	public override void Exit()
	{
		base.Exit();
	}

	public override void Update()
	{
		base.Update();

		if (axis_X == player.faceDir && player.isWall)
		{
			return;
		}

		if (axis_X != 0 && !player.isBusy)
		{
			state_machine.ChangeState(player.state_Move);
		}
	}
}
