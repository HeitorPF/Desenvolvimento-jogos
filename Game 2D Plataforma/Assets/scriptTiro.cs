using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class scriptTiro : MonoBehaviour
{
    private Rigidbody2D rbd;
    public float vel;
    private BoxCollider2D boxCollider2D;
    private Animator ani;
    private bool autoDestruindo = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        autoDestruir();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rbd = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        StartCoroutine(temporizador());
    }

    // Update is called once per frame
    void Update()
    {

    }


    IEnumerator temporizador()
    {
        yield return new WaitForSeconds(.7f);
        if (!autoDestruindo)
        {
            autoDestruir();
        }
    }
    void autoDestruir()
    {
        autoDestruindo = true;
        boxCollider2D = GetComponent<BoxCollider2D>();
        boxCollider2D.enabled = false;
        rbd.linearVelocity = new Vector2(0, 0);
        StartCoroutine(animacaoDestruicao());
    }

    IEnumerator animacaoDestruicao()
    {
        ani.SetBool("autoDestruir", true);
        yield return new WaitForSeconds(0.4f);
        Destroy(this.gameObject);
    }
}
