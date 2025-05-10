using UnityEngine;
using System.Collections.Generic; // Necesario para usar listas

public class TowerTarget : MonoBehaviour
{
    private List<Transform> targets = new List<Transform>(); // Lista de objetivos
    public float rotationSpeed = 5f; // Velocidad de rotación
    private Quaternion initialRotation; // Rotación inicial de la torre
    private ITorreManager torreManager; // Referencia al manager de la torre

    private void Start() 
    {
        torreManager = GetComponent<ITorreManager>();
        initialRotation = transform.rotation; // Guarda la rotación inicial de la torre
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            targets.Add(other.transform); // Añade al enemigo a la lista de objetivos
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            targets.Remove(other.transform); // Elimina el enemigo de la lista de objetivos
        }
    }


    void Update()
    {
        targets.RemoveAll(targets => targets == null || !targets.gameObject.activeInHierarchy); // Elimina los objetivos nulos o inactivos
        
        if (targets.Count > 0)
        {
            Transform target = targets[0]; // Obtiene el primer objetivo de la lista

            if (target != null)
            {
                // Rotar la torre hacia el objetivo
                Vector3 direction = target.position - transform.position;
                Quaternion lookRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
        
                torreManager?.Atacar(target); // Llama al método de ataque de la ballesta
            }
            else
            {
                targets.RemoveAt(0); // Elimina el objetivo si es nulo
            }
        }
        else
        {
            // Si no hay objetivo, vuelve a la rotación inicial
            transform.rotation = Quaternion.Slerp(transform.rotation, initialRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
