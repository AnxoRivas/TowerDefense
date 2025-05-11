using UnityEngine;

public class BallestaManager : MonoBehaviour, ITorreManager
{
    [SerializeField] float Daño = 5f; //Daño de la torreta.
    [SerializeField] float VelocidadDisparo = 1f; //Velocidad de disparo de la torreta.
    [SerializeField] GameObject proyectilPrefab; // Prefab del proyectil.

    private float tiempoDesdeUltimoDisparo = 0f; // Tiempo desde el último disparo.



    public void Atacar(Transform target)
    {
        if (Time.time >= tiempoDesdeUltimoDisparo + VelocidadDisparo)
        {
            LanzarProyectil(target); // Lanza un proyectil hacia el objetivo.
            tiempoDesdeUltimoDisparo = Time.time; // Reinicia el temporizador de disparo.
        }
    }

    private void LanzarProyectil(Transform target)
    {
        if (proyectilPrefab != null && target != null)
        {
            GameObject proyectil = Instantiate(proyectilPrefab, transform.position, Quaternion.identity);

            Proyectil scriptProyectil = proyectil.GetComponent<Proyectil>();
            if (scriptProyectil != null)
            {
                scriptProyectil.Configurar(target, Daño);
            }
        }
    }
    void Update()
    {
        
    }
}
