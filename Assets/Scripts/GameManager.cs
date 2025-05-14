using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; } // Instancia del GameManager

    [SerializeField] private UIManager uiManager; // Referencia al UIManager

    public int vidas = 3; // Vidas del jugador
    public int recursos = 0; // Recursos del jugador

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this; // Asigna la instancia
            DontDestroyOnLoad(gameObject); // No destruir al cargar una nueva escena
        }
        else
        {
            Destroy(gameObject); // Destruir el objeto si ya existe una instancia
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestarVida()
    {
        vidas--;
        if (vidas <= 0)
        {
            // Aquí puedes manejar la lógica de Game Over
            Debug.Log("Game Over");
        }
    }

    public void SumarRecursos(int cantidad)
    {
        recursos += cantidad;
        Debug.Log("Recursos: " + recursos);
        uiManager.ActualizarTexto(); // Actualiza el texto en el UIManager
    }


}
