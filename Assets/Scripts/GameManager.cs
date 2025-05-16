using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; } // Instancia del GameManager

    [SerializeField] private UIManager uiManager; // Referencia al UIManager
    public GameObject GameOverUI; // Reference to the Game Over UI

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

    public void RestarVida()
    {
        vidas--;
        if (vidas <= 0)
        {
            vidas = 0; // Asegurarse de que las vidas no sean negativas
            GameOverUI.SetActive(true); // Mostrar la pantalla de Game Over
            Time.timeScale = 0; // Pausar el juego
        }
        else
        {
            uiManager.ActualizarTexto(); // Actualiza el texto en el UIManager
        }
    }

    public void SumarRecursos(int cantidad)
    {
        recursos += cantidad;
        uiManager.ActualizarTexto(); // Actualiza el texto en el UIManager
    }

    public void RestarRecursos(int cantidad)
    {
        recursos -= cantidad;
        Debug.Log("Recursos Gastados");
        uiManager.ActualizarTexto();
    }


}
