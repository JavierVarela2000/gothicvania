using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState 
{
    protected EnemyStateMachine stateMachine;
    protected Enemy enemy;

    protected bool triggerCalled;
    protected float stateTimer;
    private string animBoolName;

    public EnemyState(EnemyStateMachine _stateMachine, Enemy _enemy,string _animBoolName)
    {
        this.stateMachine = _stateMachine;
        this.enemy = _enemy;
        this.animBoolName = _animBoolName;
    }

    public virtual void Update()
    {
        stateTimer -= Time.deltaTime;
    }

    public virtual void Enter()
    {
        triggerCalled = false;
        enemy.animator.SetBool(animBoolName, true);
    }

    public virtual void Exit()
    {
        enemy.animator.SetBool(animBoolName, false);
    }


}
