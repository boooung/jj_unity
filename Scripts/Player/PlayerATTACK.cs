using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerATTACK : PlayerFSMState
{
    public override void BeginState()
    {
        base.BeginState();
        manager.anim.CrossFade("KK_Attack");
    }

    private void Update()
    {
        
    }
}
