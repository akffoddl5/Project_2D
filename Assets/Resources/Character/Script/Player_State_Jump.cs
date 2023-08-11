using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_State_Jump : Player_State
{
	public Player_State_Jump(Player _player, Player_State_Machine _state_machine, string _anim_bool_name) : base(_player, _state_machine, _anim_bool_name)
	{
	}

	public override void Enter()
	{
		base.Enter();
		player.rb.AddForce(Vector2.up * player.jump_force, ForceMode2D.Impulse);
	}

	public override void Exit()
	{
		base.Exit();
	}

	public override void Update()
	{
		base.Update();
		if (player.rb.velocity.y <0)
		{
			player.state_machine.ChangeState(player.state_Air);
		}

		if (axis_X != 0)
		{
			player.Set_Velocity(player.move_speed * 0.8f * axis_X, player.rb.velocity.y);
		}
	}
}
