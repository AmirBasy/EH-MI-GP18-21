using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BS_TimeBaseState : BaseBossState
{
    public float stateDuration = 5;
    float endTime;

    public override void Enter()
    {
        endTime = Time.time + stateDuration;
    }

    public override void Tick()
    {
        if (Time.time >= endTime) TriggerExitState();
    }
}
