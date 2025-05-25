using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class scriptPC : MonoBehaviour
{
    // tiro e tp
    public GameObject tiro;
    private GameObject tiroAtual;
    private bool atirando = false;
    public float tempoTiro;
    private bool atirandoAnimacao = false;


    //atacando
    private bool isAttacking = false;

    //
    public LayerMask mascara;
    private Rigidbody2D rbd;
    public GameObject pe;
    public GameObject areaAttack;
    public float vel;
    public float pulo;
    private bool chao;
    private Animator ani;
    public bool direita = true;

    // dash
    private bool canDash = true;
    private bool isDashing;
    public float dashingPower;
    public float dashingTime;

    private float dashCooldown;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dashingPower = 5f;
        dashingTime = .2f;
        dashCooldown = 1f;
        tempoTiro = .7f;
        vel = 5f;
        pulo = 800f;
        areaAttack.SetActive(false);
        rbd = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDashing || atirandoAnimacao)
        {
            return;
        }
        float x = Input.GetAxis("Horizontal");
        rbd.linearVelocity = new Vector2(x * vel, rbd.linearVelocity.y);

        if (x == 0)
        {
            ani.SetBool("movendo", false);
        }
        else
        {
            ani.SetBool("movendo", true);
        }

        if (Input.GetKeyDown(KeyCode.Space) && chao)
        {
            rbd.AddForce(new Vector2(0, pulo));
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }
        if (Input.GetKeyDown(KeyCode.Mouse1) && !atirando && chao) // atirar
        {
            StartCoroutine(Atirar());
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && !atirando && chao) // atacar
        {
            StartCoroutine(Atacar());
        }

        // Detecta direção

        if (x < 0 && direita || x > 0 && !direita)
        {
            transform.Rotate(new Vector2(0, 180));
            direita = !direita;
        }



        // Detecta chão
        RaycastHit2D hit;
        hit = Physics2D.Raycast(pe.transform.position, Vector2.down, 0.3f, mascara);

        if (hit.collider == null)
        {
            chao = false;
            ani.SetBool("chao", chao);
            ani.SetBool("pulando", true);
        }
        else
        {
            chao = true;
            ani.SetBool("chao", chao);
            ani.SetBool("pulando", false);
        }


    }

    private IEnumerator Atacar()
    {
        isAttacking = true;
        ani.SetBool("atacando", true);
        areaAttack.SetActive(true);
        yield return new WaitForSeconds(.5f);
        isAttacking = false;
        ani.SetBool("atacando", false);
        areaAttack.SetActive(false);
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        ani.SetBool("isDashing", isDashing);
        float originalGravity = rbd.gravityScale;
        rbd.gravityScale = 0f;
        if (direita)
        {
            rbd.linearVelocity = new Vector2(vel * dashingPower, 0f);
        }
        else
        {
            rbd.linearVelocity = new Vector2(-vel * dashingPower, 0f);
        }

        yield return new WaitForSeconds(dashingTime);
        rbd.gravityScale = originalGravity;
        rbd.linearVelocity = new Vector2(0, 0);
        isDashing = false;
        ani.SetBool("isDashing", isDashing);
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }

    private IEnumerator Atirar()
    {
        atirandoAnimacao = true;
        ani.SetBool("atirando", atirandoAnimacao);
        rbd.linearVelocity = new Vector2(0, 0);
        float vel = 15;
        yield return new WaitForSeconds(.666f);
        Debug.Log("Quase tiro");
        if (direita)
        {
            tiroAtual = Instantiate(tiro, new Vector2(rbd.position.x + .8f, rbd.position.y + .5f), Quaternion.identity);
            tiroAtual.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(vel, 0);

        }
        else
        {
            tiroAtual = Instantiate(tiro, new Vector2(rbd.position.x - .8f, rbd.position.y + .5f), quaternion.Euler(0, 180, 0));
            tiroAtual.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(-vel, 0);

        }

        yield return new WaitForSeconds(.333f);
        atirandoAnimacao = false;
        ani.SetBool("atirando", atirandoAnimacao);
    }

    public void LevarDano(float dano)
    {
        Debug.Log("Levei "+ dano +" de dano");
    }
}


