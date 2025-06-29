using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SocialPlatforms.Impl;

public class scriptPC : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI chackraText;
    public TextMeshProUGUI vidaText;
    private int score;
    private int chackra;
    private int vida;

    private Rigidbody rbd;
    public float vel;
    public float forcaPulo;
    private Quaternion rotIni;
    public float velRotY;
    private float countY;

    public GameObject cabeca;
    public LayerMask mascara;
    public float dist;
    private AudioSource[] sons;
    private AudioSource somRasengan;
    private AudioSource somItadakimasu;
    private AudioSource somKuso;
    private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rbd = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        sons = GetComponents<AudioSource>();
        somRasengan = sons[0];
        somItadakimasu = sons[1];
        somKuso = sons[2];
        rotIni = transform.localRotation;
        velRotY = 100;
        dist = 100;
        forcaPulo = 450;
        vel = 3;
        score = 0;
        chackra = 0;
        vida = 3;
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
                animator.SetBool("isRunning", false);
                animator.SetBool("isWalkingRight", true);

            }
            else if (frente == 0 && lado < 0)
            {
                animator.SetBool("isRunning", false);
                animator.SetBool("isWalkingLeft", true);
            }

        }


        if (Input.GetMouseButtonDown(0))
            UsarRasengan();

        if (Input.GetKeyDown(KeyCode.Space) && estaNoChao)
        {
            animator.SetBool("isJumping", true);
            rbd.AddForce(Vector3.up * forcaPulo, ForceMode.Impulse); // valor ajustável
        }
    }

    public void SetRotacaoY(float y)
    {
        countY = y;
    }

    public void UpdateScore(int score)
    {
        this.score += score;
        scoreText.text = "score: " + this.score.ToString();
    }

    public void UpdateChackra(int chackra)
    {
        this.chackra += chackra;
        if (chackra > 0)
            somItadakimasu.Play();
        chackraText.text = "chackra: " + this.chackra.ToString();
    }

    public void UpdateVida(int vida)
    {
        if (vida < 0)
            somKuso.Play();
        this.vida += vida;
        vidaText.text = "Vida: " + this.vida.ToString();
        if (this.vida <= 0)
        {
            //Game over
        }
    }

    public void UsarRasengan()
    {
        if (chackra >= 60)
        {
            UpdateChackra(-60);
            RaycastHit hit;
            somRasengan.Play();
            if (Physics.Raycast(cabeca.transform.position, cabeca.transform.forward, out hit, dist, mascara))
            {
                NavMeshAgent agente = hit.collider.GetComponent<NavMeshAgent>();
                if (agente != null)
                    agente.Warp(new Vector3(7, 1, 1)); // forma correta de teleportar um agente
            }
        }
    }
}

