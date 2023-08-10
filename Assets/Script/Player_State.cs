using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_State
{
    public Player_State_Machine state_machine;
    public Player player;
    public string anim_bool_name;

    

    public Player_State(Player _player, Player_State_Machine _state_machine, string _anim_bool_name)
    {
        player = _player;
        state_machine = _state_machine;
        anim_bool_name = _anim_bool_name;

    }

	public virtual void Enter()
	{
        player.anim.SetBool(anim_bool_name, true);
	}

    public virtual void Update()
    {
        player.axis_X = Input.GetAxisRaw("Horizontal");
        player.dash_cool_time -= Time.deltaTime;
        player.dash_time -= Time.deltaTime;
        player.anim.SetFloat("yVelocity", player.rb.velocity.y);

    }

	public virtual void Exit()
	{
        player.anim.SetBool(anim_bool_name, false);
	}

    
    

}
