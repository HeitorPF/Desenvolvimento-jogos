using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptFundo : MonoBehaviour
{
    private Rigidbody2D rbd;
    public float vel = 1;
    // Start is called before the first frame update
    void Start()
    {
        rbd = this.GetComponent<Rigidbody2D>();
        rbd.velocity = new Vector2(0, -vel);
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y < -Camera.main.orthographicSize * 2)
        {
            this.transform.position = new Vector2(0, Camera.main.orthographicSize * 2);
        }
    }
}
