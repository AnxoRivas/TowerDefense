using UnityEngine;

public class TowerTarget : MonoBehaviour
{
    private Transform target; // El objetivo
    public float rotationSpeed = 5f; // Velocidad de rotación
    private Quaternion initialRotation; // Rotación inicial de la torre
    private BallestaManager ballestaManager; // Referencia al script de la ballesta

    private void Start() 
    {
        ballestaManager = GetComponent<BallestaManager>();
        initialRotation = transform.rotation; // Guarda la rotación inicial de la torre
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            target = other.transform; // Asigna el objetivo al enemigo que entra en el trigger
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            target = null; // Elimina el objetivo cuando el enemigo sale del trigger
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            // Rotar la torre hacia el objetivo
            Vector3 direction = target.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
        
            ballestaManager.Atacar(target); // Llama al método de ataque de la ballesta
        }
        else
        {
            // Si no hay objetivo, vuelve a la rotación inicial
            transform.rotation = Quaternion.Slerp(transform.rotation, initialRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
