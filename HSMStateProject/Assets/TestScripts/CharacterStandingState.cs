using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterStandingState : CharacterHSMState
{
    public CharacterStandingState(Character.State stateId, string debugName = null) : base(stateId, debugName)
    {

    }

    protected override void OnEnter()
    {
        base.OnEnter();

        character.spriteRenderer.color = Color.white;
    }

    protected override void OnExit()
    {
        base.OnExit();
    }
}