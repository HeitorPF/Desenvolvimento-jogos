using System.Collections;
using UnityEngine;

public class scriptFinalBoss : inimigoBase
{
    public GameObject rangeAtk1;
    private float cooldownAtkMover = .7f;
    void Start()
    {
        rangeAtk1.SetActive(false);
        Iniciar();
        vida = 5;
        vel = 10;
        distanciaAtk = 1;
        hitBox = GetComponent<BoxCollider2D>();
        deathTime = 1.83f;
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

        yield return new WaitForSeconds(.7f);//inicio do atk
        rangeAtk1.SetActive(true);
        yield return new WaitForSeconds(.13f);//duração atk
        rangeAtk1.SetActive(false);
        atacando = false;
        ani.SetBool("atacando", atacando);

        
        yield return new WaitForSeconds(cooldownAtkMover);
        podeMover = true;
    }
}
