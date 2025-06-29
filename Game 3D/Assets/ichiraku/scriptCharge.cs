using UnityEngine;

public class scriptCharge : MonoBehaviour{
    private Coroutine esperar2Sec;
    public scriptPC pc;

    private void OnTriggerEnter(Collider outro)
    {
        if (outro.CompareTag("Player"))
        {
            // Inicia a contagem de 2 segundos
            esperar2Sec = StartCoroutine(EsperarEExecutar());
        }
    }

    private void OnTriggerExit(Collider outro)
    {
        if (outro.CompareTag("Player"))
        {
            // Cancela a coroutine se o jogador sair antes dos 2 segundos
            if (esperar2Sec != null)
            {
                StopCoroutine(esperar2Sec);
                esperar2Sec = null;
            }
        }
    }

    private System.Collections.IEnumerator EsperarEExecutar()
    {
        yield return new WaitForSeconds(2f);
        ExecutarAcao();
    }

    private void ExecutarAcao()
    {
        pc.UpdateChackra(100);
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
