using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class scriptPlataforma : MonoBehaviour
{

    private Vector2 posIni;
    public float deslocamento = 1;

    public float altura;

    private float cont = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        posIni = transform.position;
        altura = 5;
    }

    // Update is called once per frame
    void Update()
    {
        float y = Mathf.Cos(cont) * altura;

        transform.position = new Vector2(posIni.x, posIni.y + y);

        cont = cont + deslocamento * Time.deltaTime;
        if (cont > 2 * Mathf.PI)
        {
            cont = cont - 2 * Mathf.PI;
        }
    }
}
