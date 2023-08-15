using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_State_Dash : Player_State
{
    public Player_State_Dash(Player _player, Player_State_Machine _state_machine, string _anim_bool_name) : base(_player, _state_machine, _anim_bool_name)
    {
    }

    public override void Enter()
    {
        
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
		player.rb.velocity = new Vector2(0, player.rb.velocity.y);
	}

    public override void Update()
    {
        base.Update();

        if (!player.isGround && player.isWall)
        {
			state_machine.ChangeState(player.state_WallSlide);
		}

        if (player.dash_time > 0)
        {
            player.rb.velocity = new Vector2(player.dash_speed * player.faceDir, 0);
        }
        else
        {
            player.state_machine.ChangeState(player.state_Idle);
        }
        
    }
}
