using Unity.VisualScripting;
using UnityEngine;

public class scriptPC : MonoBehaviour
{
    private Rigidbody rbd;
    public float vel;
    public float forcaPulo;
    private Quaternion rotIni;
    public float velRotY;
    private float countY;

    public GameObject cabeca;
    public LayerMask mascara;
    public float dist;
    private AudioSource somRasengan;
    private Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rbd = GetComponent<Rigidbody>();
        somRasengan = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        rotIni = transform.localRotation;
        velRotY = 100;
        dist = 100;
        forcaPulo = 450;
        vel = 3;
    }

    // Update is called once per frame
    void Update()
    {

        bool estaNoChao = Physics.Raycast(transform.position, Vector3.down, .3f);
        float frente = Input.GetAxis("Vertical");
        float lado = Input.GetAxis("Horizontal");
        bool shiftDown = Input.GetKey(KeyCode.LeftShift);

        countY += Input.GetAxisRaw("Mouse X") * Time.deltaTime * velRotY;
        Quaternion rotY = Quaternion.AngleAxis(countY, Vector3.up);
        transform.localRotation = rotIni * rotY;

        if (estaNoChao)
        {
            animator.SetBool("isFalling", false);
            animator.SetBool("isJumping", false);
        }
        else
        {
            animator.SetBool("isFalling", true);
        }
        rbd.linearVelocity = transform.TransformDirection(new Vector3(lado * vel, rbd.linearVelocity.y, frente * vel));
        animator.SetBool("isWalkingRight", false);
        animator.SetBool("isWalkingLeft", false);
        animator.SetBool("isWalking", false);
        if (frente != 0 || lado != 0)
        {
            vel = 3;
            animator.SetBool("isWalking", true);
            if (shiftDown)
            {
                vel = 10;
                animator.SetBool("isRunning", true);
            }
            else
            {
                animator.SetBool("isRunning", false);
            }
            if (frente == 0 && lado > 0)
            {
                vel = 1f;
                animator.SetBool("isRunning", false);
                animator.SetBool("isWalkingRight", true);

            }
            else if (frente == 0 && lado < 0)
            {
                vel = 1f;
                animator.SetBool("isRunning", false);
                animator.SetBool("isWalkingLeft", true);
            }

        }


        if (Input.GetMouseButtonDown(0))
        {
            animator.SetBool("isAttacking", true);
            RaycastHit hit;
            somRasengan.Play();
            if (Physics.Raycast(cabeca.transform.position, cabeca.transform.forward, out hit, dist, mascara))
            {
                Rigidbody rbd = hit.collider.GetComponent<Rigidbody>();
                rbd.AddForce(cabeca.transform.forward * 600f);
            }
            animator.SetBool("isAttacking", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && estaNoChao)
        {
            animator.SetBool("isJumping", true);
            rbd.AddForce(Vector3.up * forcaPulo, ForceMode.Impulse); // valor ajustável
        }
    }

    public void SetRotacaoY(float y) {
        countY = y;
    }
}

