using UnityEngine;

public class Proyectil : MonoBehaviour
{
    private Transform target; // Objetivo al que se dirige el proyectil.
    private float daño; // Daño que inflige el proyectil.
    [SerializeField] private float velocidad = 10f; // Velocidad del proyectil.

    public void Configurar(Transform target, float daño)
    {
        this.target = target; // Asigna el objetivo.
        this.daño = daño; // Asigna el daño.
    }
    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject); // Destruye el proyectil si no hay objetivo.
            return;
        }
        // Mover el proyectil hacia el objetivo.
        Vector3 direccion = (target.position - transform.position).normalized;
        transform.position += direccion * velocidad * Time.deltaTime;

        transform.rotation = Quaternion.LookRotation(direccion); // Rotar el proyectil hacia la dirección del movimiento.

        // Comprobar si el proyectil ha alcanzado al objetivo.
        if (Vector3.Distance(transform.position, target.position) < 0.2f)
        {
            Impactar();
        }
    }

    private void Impactar()
    {
        IEnemigo enemigo = target.GetComponent<IEnemigo>();
        if (enemigo != null)
        {
            enemigo.RecibirDanio(daño); // Aplica el daño al enemigo.
            Destroy(gameObject); // Destruye el proyectil después de impactar.
        }
        Destroy(gameObject); // Destruye el proyectil después de impactar.
    }
}
