using System.Collections;
using UnityEngine;

public class scriptFinalBoss : inimigoBase
{
    private float cooldownAtkMover = 2f;
    void Start()
    {
        Iniciar();
        vida = 5;
        vel = 10;
        distanciaAtk = 2;
    }

    protected override void Atacar()
    {
        
        StartCoroutine(ataque1());
        Debug.Log(name + " atacou!");
        
    }

    IEnumerator ataque1()
    {
        atacando = true;
        ani.SetBool("atacando", atacando);
        rbd.linearVelocity = new Vector2(0, 0);
        podeMover = false;
        ani.SetBool("andando", false);
        yield return new WaitForSeconds(.84f);
        atacando = false;
        ani.SetBool("atacando", atacando);
        yield return new WaitForSeconds(cooldownAtkMover);
        podeMover = true;
    }
}
