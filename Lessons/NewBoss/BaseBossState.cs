using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBossState : BaseState
{
    protected PlayerController player;
    protected BossController boss;

    protected const string END_STATE_TRIGGER = "EndState";

    public override void SetContext(object context, Animator animator)
    {
        base.SetContext(context, animator);
        boss = context as BossController;
        player = boss.player;

    }

    protected void TriggerExitState()
    {
        animator.SetTrigger(END_STATE_TRIGGER);
    }
}
