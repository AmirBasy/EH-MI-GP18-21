using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NavMeshController : MonoBehaviour
{
    NavMeshAgent agent;
    public Animator animator;

    List<Vector3> targetPositions = new List<Vector3>();
    int assignedTargetPosition = 0;

    public Transform debugSphere;

    public float distanceTarget = 2;

    // Start is called before the first frame update
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();

        for (int angle = 0; angle < 360; angle+=35)
        {
            targetPositions.Add(Quaternion.AngleAxis(angle, Vector3.up) * Vector3.forward * distanceTarget);
        }

    }

    public Vector3 GetFreeTargetPosition()
    {
        var target = targetPositions[assignedTargetPosition];
        assignedTargetPosition++;
        return target;
    }
    

    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray,out hit))
            {
                debugSphere.transform.position = agent.destination = hit.point;
                //agent.SetDestination(hit.point);
            }

        }



    }
}
