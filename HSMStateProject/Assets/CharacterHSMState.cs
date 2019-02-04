using System;
using UnityEngine;

[Serializable]
public struct CharacterHSMTransition : IHSMTransitionSerializationWrapper<Character.State, Character.Trigger>
{
    [SerializeField]
    public Character.State stateFrom;
    [SerializeField]
    public Character.Trigger trigger;
    [SerializeField]
    public Character.State stateTo;

    public HSMTransition<Character.State, Character.Trigger> ToHSMTransition()
    {
        return new HSMTransition<Character.State, Character.Trigger>(stateFrom, trigger, stateTo);
    }
}

public abstract class CharacterHSMState : HSMState<Character.State, Character.Trigger>
{
    protected Character character;

    protected Character.Trigger lastTrigger;

    protected CharacterHSMState(Character.State stateId, string debugName = null) : base(stateId, debugName)
    {

    }

    protected override void OnEnter()
    {
        Debug.Log(DebugName);
    }

    public void PropagateCharacterReference(Character characterRef)
    {
        CharacterHSMState root = (CharacterHSMState)GetRoot();

        root.InternalPropagateCharacterReference(characterRef);
    }

    private void InternalPropagateCharacterReference(Character characterRef)
    {
        for (int i = 0; i < parallelChilds.Count; i++)
        {
            ((CharacterHSMState)parallelChilds[i]).InternalPropagateCharacterReference(characterRef);
        }

        for(int i = 0; i < childs.Count; i++)
        {
            ((CharacterHSMState)childs[i]).InternalPropagateCharacterReference(characterRef);
        }

        character = characterRef;
    }

    private void OnTriggerReceived(HSMState<Character.State, Character.Trigger> state, Character.Trigger trigger)
    {
        lastTrigger = trigger;
    }
}
