using System;
using UnityEngine;
using UnityEngine.AI;
public class scriptNPC : MonoBehaviour
{
    public GameObject player;
    public scriptPC pc;
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
        agente = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agente.SetDestination(player.transform.position);
    }
}
