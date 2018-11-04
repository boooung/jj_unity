using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRUN : PlayerFSMState
{

    public override void BeginState()
    {
        base.BeginState();
        manager.anim.CrossFade("KK_Run_No");
    }


	void Update ()
	{
        GameLib.JJMove(manager.cc, manager.marker, manager.stat);
       

        Vector3 diff = manager.marker.position - transform.position;
        diff.y = 0.0f;
        if(diff.magnitude < 0.1f)
        {
            manager.SetState(PlayerState.IDLE);
        }
     
	}
}
