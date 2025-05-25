using UnityEngine;

public class controladorDano : MonoBehaviour
{
    protected float dano = 0;
    protected string atacante;
    protected inimigoBase inimigo;
    protected scriptPC pc;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Inimigo") && atacante.Equals("pc"))
        {
            inimigo = other.GetComponent<inimigoBase>();
            if (inimigo != null)
            {
                inimigo.LevarDano(dano);
            }
        }
        else if (other.name == "PC" && atacante.Equals("inimigo"))
        {
            pc = other.GetComponent<scriptPC>();
            if (pc != null)
            {
                pc.LevarDano(dano);
            }
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
