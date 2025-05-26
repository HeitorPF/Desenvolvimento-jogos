using UnityEngine;

public class scriptQuedaBox1 : MonoBehaviour
{

    private inimigoBase inimigo;
    private scriptPC pc;
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Inimigo"))
        {
            inimigo = other.GetComponent<inimigoBase>();
            Destroy(inimigo);
        }
        else if (other.CompareTag("Player"))
        {
            pc = other.GetComponent<scriptPC>();
            pc.resetar();
        }
    }

}
