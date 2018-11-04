using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIDLE : PlayerFSMState
{
    public override void BeginState()
    {
        base.BeginState();
        manager.anim.CrossFade("KK_Idle");
    }

    void Update ()
    {

        

    }
}
