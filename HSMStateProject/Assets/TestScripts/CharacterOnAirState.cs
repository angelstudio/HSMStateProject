using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterOnAirState : CharacterHSMState
{
    public CharacterOnAirState(Character.State stateId, string debugName = null) : base(stateId, debugName)
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