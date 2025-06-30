using TMPro;
using UnityEngine;

public class scriptKunai : MonoBehaviour
{

    public scriptPC pc;
    void OnTriggerEnter(Collider outro)
    {
        if (outro.CompareTag("Player"))
        {
            pc.UpdateScore(10);
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
