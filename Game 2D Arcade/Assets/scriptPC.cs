using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptPC : MonoBehaviour
{
    private Rigidbody2D rbd;
    public float vel;
    private float altura;
    private float largura;
    public GameObject Tiro;
    private AudioSource som;
    private float alturaNave;



    // Start is called before the first frame update
    void Start()
    {
        rbd = this.GetComponent<Rigidbody2D>(); //Referencia ao RigidBody2d no mesmo GameObject em que o script está
        som = this.GetComponent<AudioSource>();
        vel = 10;
        altura = Camera.main.orthographicSize;
        largura = altura * Camera.main.aspect;
        alturaNave = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        // float x = Input.GetAxis("Horizontal"); //Verifica se usuario está apertando botões para horizontal
        // float y = Input.GetAxis("Vertical"); //Verifica se usuario está apertando botões para vertical
        // Vector2 vel = new Vector2(); //Cria um vetor de duas direções para usar na velocidade
        // vel.x = x; //velocidade horizontal
        // vel.y = y; //velocidade

        // rbd.velocity = vel;

        float x = Input.GetAxis("Horizontal"); //Verifica se usuario está apertando botões para horizontal
        float y = Input.GetAxis("Vertical"); //Verifica se usuario está apertando botões para vertical

        rbd.velocity = new Vector2(x, y) * vel;

        if (this.transform.position.x < -largura)
        {
            this.transform.position = new Vector2(largura, this.transform.position.y);
        }
        else if (this.transform.position.x > largura)
        {
            this.transform.position = new Vector2(-largura, this.transform.position.y);
        }

        if (this.transform.position.y > 0)
        {
            this.transform.position = new Vector2(this.transform.position.x, 0);
        }
        else if (this.transform.position.y < -altura + alturaNave/2)
        {
            this.transform.position = new Vector2(this.transform.position.x, -altura + alturaNave/2);
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Vector2 pos = new Vector2(this.transform.position.x, this.transform.position.y + alturaNave / 2);
            Instantiate(Tiro, pos, Quaternion.identity);
            som.Play();
        }
    }
}
