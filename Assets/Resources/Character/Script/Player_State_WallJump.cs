using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_State_WallJump : Player_State
{
	public Player_State_WallJump(Player _player, Player_State_Machine _state_machine, string _anim_bool_name) : base(_player, _state_machine, _anim_bool_name)
	{
	}

	public override void Enter()
	{
		base.Enter();

		state_timer = 0f;

		player.Set_Velocity(2 * -player.faceDir, player.jump_force);
		
	}

	public override void Exit()
	{
		base.Exit();
	}

	public override void Update()
	{
		base.Update();
		if (state_timer < 0)
		{
			state_machine.ChangeState(player.state_Air);
		}

		if (player.isGround)
		{
			state_machine.ChangeState(player.state_Idle);
		}
	}
}
