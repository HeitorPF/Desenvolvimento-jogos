using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scriptNPC : MonoBehaviour
{
    private Rigidbody2D rbd;
    public float vel = 5;
    void OnTriggerEnter2D(Collider2D col)
    {
        
        scriptPlacar.addPlacar(5);
        Destroy(col.gameObject);
        Destroy(this.gameObject);

    }

    // Start is called before the first frame update
    void Start()
    {
        rbd = GetComponent<Rigidbody2D>();
        rbd.velocity = new Vector2(0, -vel);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -Camera.main.orthographicSize)
        {
            Destroy(this.gameObject);
        }
    }
}
