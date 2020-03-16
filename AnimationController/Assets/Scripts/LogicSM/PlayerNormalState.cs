using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNormalState : PlayerBaseState
{
    public PlayerBaseState jumpState;
    public override void Tick(PlayerController.InputData data)
    {
        // logica
        if (data.running) data.forward = data.forward * 2;
        player.targetForward = Mathf.Lerp(player.targetForward, data.forward, Time.deltaTime * 4);



        player.Move();
        player.Rotate(data.rotate);
        player.UpdatePositionAndRotation();


        if (data.sinistro)
        {
            if (player.impulseSource != null) player.impulseSource.GenerateImpulse();

            player.animator.SetTrigger(Random.Range(0, 100) > 50 ? "l1" : "l2");
            player.Punch();
        }
        if (data.destro)
        {
            if (player.impulseSource != null) player.impulseSource.GenerateImpulse();

            player.animator.SetTrigger(Random.Range(0, 100) > 50 ? "r1" : "r2");
            player.Punch();
        }

        //rendering
        player.animator.SetFloat("forward", player.targetForward);
        player.animator.SetFloat("rotate", data.rotate);

        if (data.jump) player.ChangeState(jumpState);

        float pForw = player.targetForward;
        if (player.mixCamera!=null)
        {
            player.mixCamera.m_Weight1 = pForw;
        }

        /*
        if (data.dash)
        {
            animator.SetTrigger("dash");
            dashTimeStart = Time.time;
            state = GameState.Dash;
        }
        */
    }

}
