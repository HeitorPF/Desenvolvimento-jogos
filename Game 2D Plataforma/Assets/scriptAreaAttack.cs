using UnityEngine;

public class scriptAreaAttack : MonoBehaviour
{
    inimigoBase inimigo;
    void OnTriggerEnter2D(Collider2D other)
    {
        inimigo = other.GetComponent<inimigoBase>();
        if (inimigo != null)
        {
            inimigo.LevarDano(1);
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
