using Unity.VisualScripting;
using UnityEngine;

public class scriptPC : MonoBehaviour
{
    private Rigidbody rbd;
    public float vel = 10;
    public float forcaPulo;
    private Quaternion rotIni;
    public float velRotY;
    private float countY;

    public GameObject cabeca;
    public LayerMask mascara;
    public float dist;
    private AudioSource somTiro;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rbd = GetComponent<Rigidbody>();
        somTiro = GetComponent<AudioSource>();
        rotIni = transform.localRotation;
        velRotY = 100;
        dist = 100;
        forcaPulo = 80;
    }

    // Update is called once per frame
    void Update()
    {

        bool estaNoChao = Physics.Raycast(transform.position, Vector3.down, 1.1f);
        float frente = Input.GetAxis("Vertical");
        float lado = Input.GetAxis("Horizontal");

        countY += Input.GetAxisRaw("Mouse X") * Time.deltaTime * velRotY;
        Quaternion rotY = Quaternion.AngleAxis(countY, Vector3.up);
        transform.localRotation = rotIni * rotY;

        rbd.linearVelocity = transform.TransformDirection(new Vector3(lado * vel, rbd.linearVelocity.y, frente * vel));

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            somTiro.Play();
            if (Physics.Raycast(cabeca.transform.position, cabeca.transform.forward, out hit, dist, mascara))
            {
                Rigidbody rbd = hit.collider.GetComponent<Rigidbody>();
                rbd.AddForce(cabeca.transform.forward * 600f);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && estaNoChao)
        {
            rbd.AddForce(Vector3.up * forcaPulo, ForceMode.Impulse); // valor ajustável
        }
    }

    public void SetRotacaoY(float y) {
        countY = y;
    }
}

