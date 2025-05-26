using System.Collections;
using UnityEngine;

public class scriptShadowMedium : inimigoBase
{
    public GameObject rangeAtk1;
    private float cooldownAtkMover = 2f;
    void Start()
    {
        hitBox = GetComponent<BoxCollider2D>();
        rangeAtk1.SetActive(false);
        Iniciar();
        vida = 3;
        vel = 5;
        distanciaAtk = 1.5f;
        deathTime = .83f;
    }

    protected override void Atacar()
    {
        StartCoroutine(ataque1());
    }

    IEnumerator ataque1()
    {
        atacando = true;
        ani.SetBool("atacando", atacando);
        rbd.linearVelocity = new Vector2(0, 0);
        podeMover = false;
        ani.SetBool("andando", false);

        yield return new WaitForSeconds(.33f);//inicio do atk
        rangeAtk1.SetActive(true);
        yield return new WaitForSeconds(.33f);//duração atk
        rangeAtk1.SetActive(false);
        atacando = false;
        ani.SetBool("atacando", atacando);


        yield return new WaitForSeconds(cooldownAtkMover);
        podeMover = true;
    }
    
}
