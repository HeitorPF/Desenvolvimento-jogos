using TMPro;
using UnityEngine;

public class scriptKunai : MonoBehaviour
{

    public scriptPC pc;
    void OnTriggerEnter(Collider outro)
    {
        pc.UpdateScore(10);
        if (outro.CompareTag("Player"))
        {
            Destroy(gameObject);
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
