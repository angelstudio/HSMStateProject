using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPushingState : CharacterHSMState
{
    public CharacterPushingState(Character.State stateId, string debugName = null) : base(stateId, debugName)
    {

    }

    protected override void OnEnter()
    {
        base.OnEnter();

        character.spriteRenderer.color = Color.green;
    }

    protected override void OnExit()
    {
        base.OnExit();

        character.spriteRenderer.color = Color.white;
    }
}
