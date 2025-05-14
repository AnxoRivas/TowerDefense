using UnityEngine;
using UnityEngine.SceneManagement; // Importa el espacio de nombres para la gestión de escenas

public class MainMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        // Aquí puedes cargar la escena del juego
        Debug.Log("Iniciando el juego...");
        SceneManager.LoadScene("Juego");
    }

    public void QuitGame()
    {
        // Aquí puedes agregar lógica para guardar el progreso o mostrar un mensaje de confirmación
        Debug.Log("Saliendo del juego...");
        Application.Quit(); // Cierra la aplicación
    }
}
