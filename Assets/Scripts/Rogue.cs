using UnityEngine;

public class Rogue : MonoBehaviour, IEnemigo // Cambiar para implementar la interfaz
{
    [SerializeField] private float Vida = 30f; // Vida del rogue.
    private ObjectPool pool; // Referencia al Object Pool.

    private void Start()
    {
        pool = FindObjectOfType<ObjectPool>();
    }

    public void RecibirDanio(float danio)
    {
        Vida -= danio;
        Debug.Log("Vida del rogue: " + Vida);

        if (Vida <= 0)
        {
            Vida = 30f; // Reinicia la vida para la próxima vez que se use.
            pool.ReturnObject(gameObject); // Devuelve el rogue al pool.
            Debug.Log("El rogue ha sido desactivado y devuelto al pool.");
        }
    }
}
