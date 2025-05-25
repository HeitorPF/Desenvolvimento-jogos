using System.Collections;
using UnityEngine;

public class scriptShadowEasy : inimigoBase
{
    void Start()
    {
        Iniciar();
        vida = 2;
        vel = 3;
    }
    
    // protected override virtual void  Atacar()
    // {
    //     Debug.Log(name + " atacou!");
    // }
    // void Start()
    // {
    //     spriteRenderer = GetComponent<SpriteRenderer>();
    //     rbd = GetComponent<Rigidbody2D>();
    //     vida = 2;
    //     if (spriteRenderer != null)
    //     {
    //         corOriginal = spriteRenderer.color;
    //     }
    // }

}
