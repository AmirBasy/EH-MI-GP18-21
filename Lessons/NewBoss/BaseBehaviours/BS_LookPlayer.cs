using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BS_LookPlayer : BaseBossState
{
    public float velocitaRotazione=50;

    public override void Tick()
    {
        // direzione player
        float angle = boss.LookPlayer(velocitaRotazione);

        if (angle<1) TriggerExitState();

    }
}
