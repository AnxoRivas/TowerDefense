using UnityEngine;

public class Mago : MonoBehaviour, IEnemigo
{
    [SerializeField] private float Vida = 50f; // Vida del mago.
    private ObjectPool pool; // Referencia al Object Pool.

    private void Start()
    {
        // Buscar el Object Pool en la escena.
        pool = FindObjectOfType<ObjectPool>();
    }

    public void RecibirDanio(float danio)
    {
        Vida -= danio; // Resta el daño a la vida del mago.
        Debug.Log("Vida del mago: " + Vida);

        if (Vida <= 0)
        {
            Vida = 50f; // Reinicia la vida para la próxima vez que se use.
            pool.ReturnObject(gameObject); // Devuelve el mago al pool.
            Debug.Log("El mago ha sido desactivado y devuelto al pool.");
        }
    }
}
