using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class scriptRespawn : MonoBehaviour
{
    public GameObject inimigo;
    private float altura;
    private float largura;

    // Start is called before the first frame update
    void Start()
    {
        altura = Camera.main.orthographicSize;
        largura = altura * Camera.main.aspect;
        InvokeRepeating("respawnar", 0, 1);
    }
    private void respawnar()
    {
        float posX = Random.Range(-largura, largura);
        
        //criar um inimigo
        Vector2 pos = new Vector2(posX, 5);
        Instantiate(inimigo, pos, Quaternion.identity);
    }
    // Update is called once per frame
    void Update()
    {
        //
    }
}
