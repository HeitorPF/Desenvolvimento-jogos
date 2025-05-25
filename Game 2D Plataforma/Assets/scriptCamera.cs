using UnityEngine;

public class scriptCamera : MonoBehaviour
{

    public float offSetX;
    public float offSetY;
    public GameObject Pc;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        offSetX = 5;
        offSetY = 1;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Pc.transform.position.x + offSetX, Pc.transform.position.y + offSetY, -10);
    }
}
