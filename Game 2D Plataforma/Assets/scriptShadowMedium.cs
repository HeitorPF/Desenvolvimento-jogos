using System.Collections;
using UnityEngine;

public class scriptShadowMedium : inimigoBase
{

    private float cooldownAtkMover = 2f;
    void Start()
    {
        Iniciar();
        vida = 3;
        vel = 5;
        distanciaAtk = 1.5f;
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
