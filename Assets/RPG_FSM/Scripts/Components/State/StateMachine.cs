using System;
using System.Collections;
using System.Collections.Generic;
using RPG_FSM.Scripts.Components.State;
using UnityEngine;

public abstract class StateMachine<T> : MonoBehaviour where T : IState
{
    protected T _currentState;

    protected virtual void TransitionTo(T state)
    {
        _currentState?.Exit();
        _currentState = state;
        _currentState.Enter();
    }

    protected virtual void Update()
    {
        _currentState.Update();
    }

    protected virtual void FixedUpdate()
    {
        _currentState.PhysicsUpdate();
    }
}