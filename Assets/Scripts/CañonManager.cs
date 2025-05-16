using UnityEngine;

public class CañonManager : MonoBehaviour, ITorreManager
{
    [SerializeField] private ProyectilPool proyectilPool;
    [SerializeField] float Daño = 5f; //Daño de la torreta.
    [SerializeField] float VelocidadDisparo = 1f; //Velocidad de disparo de la torreta.

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
        GameObject proyectilObj = proyectilPool.GetProyectil();
        proyectilObj.transform.position = transform.position;
        proyectilObj.transform.rotation = Quaternion.identity;

        Proyectil scriptProyectil = proyectilObj.GetComponent<Proyectil>();
        if (scriptProyectil != null)
        {
            scriptProyectil.Configurar(target, Daño);
        }
    }
}
