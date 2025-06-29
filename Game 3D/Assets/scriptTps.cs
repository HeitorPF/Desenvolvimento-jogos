using Unity.VisualScripting;
using UnityEngine;

public class espelhoTP : MonoBehaviour
{

    public GameObject view;
    public void OnTriggerEnter(Collider outro)
    {
            outro.transform.position = view.transform.position;

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
