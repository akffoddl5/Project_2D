using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_State
{
    public Player_State_Machine state_machine;
    public Player player;
    public string anim_bool_name;


	public float axis_X;
	public float axis_Y;

	public float state_timer;
	protected bool triggerCalled;



	public Player_State(Player _player, Player_State_Machine _state_machine, string _anim_bool_name)
    {
        player = _player;
        state_machine = _state_machine;
        anim_bool_name = _anim_bool_name;

    }

	public virtual void Enter()
	{
        player.anim.SetBool(anim_bool_name, true);
		triggerCalled = false;
	}

    public virtual void Update()
    {
		axis_X = Input.GetAxisRaw("Horizontal");
		axis_Y = Input.GetAxisRaw("Vertical");

		state_timer -= Time.deltaTime;


	}

	public virtual void Exit()
	{
        player.anim.SetBool(anim_bool_name, false);
	}


	protected void DashCheck()
	{
		if (Input.GetKeyDown(KeyCode.LeftShift) && player.dash_cool_time < 0)
		{
			player.dash_cool_time = player.dash_cool_time_max;
			player.dash_time = player.dash_time_max;
			player.state_machine.ChangeState(player.state_Dash);

		}
	}

	public virtual void AnimationFinishTrigger()
	{
		triggerCalled = true;
	}

	



}
