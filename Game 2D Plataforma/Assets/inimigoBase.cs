using System.Collections;
using UnityEngine;

public class inimigoBase : MonoBehaviour
{

    protected SpriteRenderer spriteRenderer;
    private Color corOriginal;
    protected Rigidbody2D rbd;
    protected Animator ani;
    public float vida = 1;
    public float vel = 4;
    public Transform alvo;
    private bool jogadorAlcance = false;
    private bool direita = true;
    private bool andando = false;
    public float distanciaAtk = 0.5f;
    protected bool atacando = false;
    protected bool podeMover = true;


    void OnTriggerStay2D(Collider2D other)
    {
        if (other.name == "PC")
        {
            jogadorAlcance = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "PC")
        {
            jogadorAlcance = false;
            andando = false;
            ani.SetBool("andando", andando);

        }
    }

    protected virtual void Atacar()
    {
        Debug.Log(name + " atacou!");
    }

    public void LevarDano(float dano)
    {
        vida -= dano;
        Debug.Log(name + " levou " + dano + " de dano. Vida restante: " + vida);
        if (spriteRenderer != null)
        {
            StartCoroutine(PiscarDano());
        }
        if (vida <= 0)
        {
            Morrer();
        }
    }

    protected void Morrer()
    {
        Debug.Log(name + " morreu!");
        Destroy(gameObject);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    protected void Iniciar()
    {
        rbd = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            corOriginal = spriteRenderer.color;
        }
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (atacando)
        {
            return;
        }
        if (jogadorAlcance && podeMover)
        {
            float posicaoAlvoX = alvo.position.x;
            float posicaoAtualX = transform.position.x;
            float distancia = posicaoAlvoX - posicaoAtualX;
            perseguirAlvo(distancia);
        }

    }

    protected virtual void perseguirAlvo(float distancia)
    {
        if (distancia >= -distanciaAtk && distancia <= distanciaAtk)
        {
            Atacar();
        }
        if (podeMover)
        {
            andando = true;
            ani.SetBool("andando", andando);
            if (distancia < 0)
            {
                rbd.linearVelocity = new Vector2(-vel, 0);
            }
            else
            {
                rbd.linearVelocity = new Vector2(vel, 0);
            }
            if (distancia < 0 && direita || distancia > 0 && !direita)
            {
                transform.Rotate(new Vector2(0, 180));
                direita = !direita;
            }
        }



    }
    IEnumerator PiscarDano()
    {
        spriteRenderer.color = Color.red; // ou Color.white para flash
        yield return new WaitForSeconds(0.1f); // tempo do flash
        spriteRenderer.color = corOriginal;
    }
    

}
