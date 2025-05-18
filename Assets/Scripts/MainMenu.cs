using UnityEngine;
using UnityEngine.SceneManagement; // Importa el espacio de nombres para la gestión de escenas

public class MainMenu : MonoBehaviour
{

    public void StartGame()
    {
        // Aquí puedes cargar la escena del juego
        SceneManager.LoadScene("Tutorial"); // Va a la escena del tutorial
    }

    public void QuitGame()
    {
        // Aquí puedes agregar lógica para guardar el progreso o mostrar un mensaje de confirmación
        Application.Quit(); // Cierra la aplicación
    }
}
