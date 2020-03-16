using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class PlayerController : MonoBehaviour
{

    public PlayerBaseState currentState;

    public Animator animator;

    public float velocita;
    public float velocitaRotazione;

    public GameObject testAnimazione;

    internal Vector3 position;
    internal Quaternion rotation;

    public Cinemachine.CinemachineMixingCamera mixCamera;
    public Cinemachine.CinemachineImpulseSource impulseSource;

    // Start is called before the first frame update
    public void Start()
    {
        position = this.transform.position;
        rotation = this.transform.rotation;
    }

    internal float targetForward;

    // a che secondo ho inziato il salto
    float jumpTimeStart;
    float dashTimeStart;

    public struct InputData
    {
        public float forward;
        public float rotate;
        public bool running;
        public bool jump;
        public bool destro;
        public bool sinistro;
        public bool dash;
    }

    InputData GetInput()
    {
        InputData data;

        // input
        data.forward = Input.GetAxis("Vertical");
        data.rotate = Input.GetAxis("Horizontal");
        data.running = Input.GetKey(KeyCode.LeftShift);
        data.jump = Input.GetKeyDown(KeyCode.Space);
        data.destro = Input.GetKeyDown(KeyCode.E);
        data.sinistro = Input.GetKeyDown(KeyCode.Q);
        data.dash = Input.GetKeyDown(KeyCode.X);

        return data;
    }

    public void ChangeState(PlayerBaseState newState)
    {
        if (currentState != null) currentState.Exit();
        newState.Enter();
        currentState = newState;
    }


    // Update is called once per frame
    void Update()
    {

        var inputData = GetInput();

        currentState.Tick(inputData);
    }

       


    public float DashTime = 1;

    public void Move()
    {
        position = position + this.transform.forward * targetForward * velocita * Time.deltaTime;
    }

    public void Rotate(float rotate)
    {
        rotation = Quaternion.Euler(Vector3.up * rotate * velocitaRotazione * Time.deltaTime) * rotation;
    }

    public void UpdatePositionAndRotation()
    {
        transform.SetPositionAndRotation(position, rotation);
    }

    /*
    void UpdateDash(InputData data)
    {
        float tempoPassato = Time.time - dashTimeStart;

        position = position + this.transform.forward * targetForward * velocita * Time.deltaTime;
        //rotation = Quaternion.Euler(Vector3.up * data.rotate * velocitaRotazione * Time.deltaTime) * rotation;
        this.transform.SetPositionAndRotation(position, rotation);


        if (tempoPassato > DashTime) state = GameState.Normal;
    }
    */

    public ParticleSystem ps;

    public void Land()
    {
        ps.Play();
    }


    public void Punch()
    {
        
    }

    public void Hit()
    {
        testAnimazione.gameObject.SetActive(false);
    }

    public void FootR()
    {

    }
}
