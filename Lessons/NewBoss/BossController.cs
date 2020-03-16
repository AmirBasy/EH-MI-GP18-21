using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public Animator animator;
    public PlayerController player;

    public MeshRenderer graphics;
    public Material normalMaterial;
    public Material AngryMaterial;


    // Start is called before the first frame update
    protected virtual void Start()
    {
        foreach (var item in animator.GetBehaviours<BaseState>())
        {
            item.SetContext(this,animator);
        }
    }

    public float LookPlayer(float velocita)
    {
        var direzione = player.transform.position - transform.position;
        float angle = Vector3.SignedAngle(transform.forward, direzione, Vector3.up);
        transform.Rotate(Vector3.up * angle * Time.deltaTime * velocita);

        return angle;
    }

}
