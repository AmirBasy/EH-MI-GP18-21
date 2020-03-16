using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewFirstBossState : BaseState
{

    protected NewFirstBossController boss;
    protected NewFirstBossData data;


    

    public override void SetContext(object context,Animator animator)
    {
        base.SetContext(context,animator);

        boss = context as NewFirstBossController;
        data = boss.data;
    }

}
