using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterIdleState : CharacterHSMState
{
    public CharacterIdleState(Character.State stateId, string debugName = null) : base(stateId, debugName)
    {

    }

    protected override void OnEnter()
    {
        base.OnEnter();
    }

    protected override void OnExit()
    {
        base.OnExit();
    }
}