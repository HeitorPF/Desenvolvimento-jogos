using System;
using UnityEngine;
using UnityEngine.AI;
public class scriptNPC : MonoBehaviour
{
    public GameObject[] wayPoints;
    public GameObject player;
    public scriptPC pc;
    private float distPersegue;
    private UnityEngine.AI.NavMeshAgent agente;
    void OnTriggerEnter(Collider outro)
    {
        if (outro.CompareTag("Player"))
        {
            pc.UpdateVida(-1);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        distPersegue = 20;
        agente = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agente.SetDestination(wayPoints[0].transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.transform.position, transform.position) < distPersegue)
        {
            agente.SetDestination(player.transform.position);
        }
        else
        {
            if (agente.remainingDistance <= .5f)
            {
                EscolherNovoDestino();
            }
            
        }
    }

    void EscolherNovoDestino()
    {
        int indiceAleatorio = UnityEngine.Random.Range(0, wayPoints.Length);
        agente.SetDestination(wayPoints[indiceAleatorio].transform.position);
    }
}
