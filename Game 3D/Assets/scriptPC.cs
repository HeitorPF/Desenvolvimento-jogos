using Unity.VisualScripting;
using UnityEngine;

public class scriptPC : MonoBehaviour
{
    private Rigidbody rbd;
    public float vel = 10;
    private Quaternion rotIni;
    public float velRotY;
    private float countY;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rbd = GetComponent<Rigidbody>();
        rotIni = transform.localRotation;
        velRotY = 100;
    }

    // Update is called once per frame
    void Update()
    {
        float frente = Input.GetAxis("Vertical");
        float lado = Input.GetAxis("Horizontal");

        countY += Input.GetAxisRaw("Mouse X") * Time.deltaTime * velRotY;
        Quaternion rotY = Quaternion.AngleAxis(countY, Vector3.up);
        transform.localRotation = rotIni * rotY;

        rbd.linearVelocity = transform.TransformDirection(new Vector3(lado * vel, rbd.linearVelocity.y, frente * vel));

    }
}
