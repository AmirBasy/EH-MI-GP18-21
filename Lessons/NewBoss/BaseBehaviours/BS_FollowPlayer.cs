using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BS_FollowPlayer : BS_TimeBaseState
{
    public float velocitaRotazione = 50;
    public float velocita = 7;

    public override void Tick()
    {
        // guardo il  player
        boss.LookPlayer(velocitaRotazione);
        // seguo il player
        boss.transform.position = boss.transform.position + boss.transform.forward * velocita * Time.deltaTime;

        base.Tick();
    }

}
