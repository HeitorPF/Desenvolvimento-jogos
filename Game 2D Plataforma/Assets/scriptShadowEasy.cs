using System.Collections;
using Unity.VisualScripting;
using UnityEngine;


public class scriptShadowEasy : inimigoBase
{
    private float cooldownAtkMover = 1.5f;
    public GameObject rangeAtk11;
    public GameObject rangeAtk12;
    void Start()
    {
        rangeAtk11.SetActive(false);
        rangeAtk12.SetActive(false);
        hitBox = GetComponent<BoxCollider2D>();
        Iniciar();
        vida = 2;
        vel = 3;
        distanciaAtk = 2;
        deathTime = 1.75f;
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
        yield return new WaitForSeconds(.166f);// Tempo do começo  do primeiro atk
        rangeAtk11.SetActive(true);
        yield return new WaitForSeconds(.133f);// Duração do primeira ataque
        rangeAtk11.SetActive(false);
        yield return new WaitForSeconds(.2f);//Inicio do segundo ataque
        rangeAtk12.SetActive(true);
        yield return new WaitForSeconds(.133f);//Duração segundo ataque
        rangeAtk12.SetActive(false);
        atacando = false;
        ani.SetBool("atacando", atacando);
        yield return new WaitForSeconds(cooldownAtkMover);
        podeMover = true;
    }
}
