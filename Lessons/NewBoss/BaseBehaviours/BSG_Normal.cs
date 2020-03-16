using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BSG_Normal : BaseBossState
{
    public override void Enter()
    {
        boss.graphics.sharedMaterial = boss.normalMaterial;
    }
}
