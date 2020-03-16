using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{
    [Header("Jump Data")]
    // l'arco del movimento
    public AnimationCurve jumpCurve;
    [Tooltip("Quanto tempo ci mette per fare tutto il salto")]
    public float jumpTime = 1;

    // altezza salto
    [Tooltip("Altezza salto (moltiplicatore della curva)")]
    public float jumpMultipler = 1;


    public PlayerBaseState normalState;

    float startTime;

    public override void Enter()
    {
        startTime = Time.deltaTime;
        player.animator.SetTrigger("jump");
    }

    public override void Tick(PlayerController.InputData data)
    {
        float tempoPassato = Time.time - startTime;

        /*
         * 
         *  inizio = 2
         *  ora (Time.time) = 3
         *  tempoPassato = 3 -2  = 1;
         *  jumpTime=4;
         *  ratio = tempoPassato / jumpTime = 1 / 4 = 0.25
         *  
         *  ora = 5
         *  tempoPassato = 5 -2 = 3
         *  ratio = tempoPassato / jumpTime = 3/4 = 0.75%
         *  
         */

        float ratio = Mathf.Clamp01(tempoPassato / jumpTime);

        player.Move();
        player.UpdatePositionAndRotation();


        player.position.y = jumpCurve.Evaluate(ratio) * jumpMultipler;
        if (ratio == 1)
        {
            player.ChangeState(normalState);
        }

    }


}
