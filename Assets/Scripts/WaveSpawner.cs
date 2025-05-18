using UnityEngine;
using System.Collections;

public class WaveSpawner : MonoBehaviour
{

    [SerializeField] private PauseMenu pauseMenu; // Referencia al PauseMenu.
    [SerializeField] private ObjectPool pool; // Referencia al Object Pool.
    [SerializeField] private Transform spawnPoint; // Punto de aparición de los magos.
    [SerializeField] private float timeBetweenWaves = 5f; // Tiempo entre oleadas.
    [SerializeField] private int enemigosPorOleada = 5; // Número de enemigos por oleada.
    [SerializeField] private int totalOleadas = 3; // Número total de oleadas.
    [SerializeField] private float delayEntreEnemigos = 0.5f; // Tiempo entre la aparición de cada enemigo.

    private int oleadaActual = 0; // Contador de oleadas.
    private float countdown = 5f;

private bool endGameStarted = false;

private void Update()
{
    countdown -= Time.deltaTime;

    if (countdown <= 0f && oleadaActual < totalOleadas)
    {
        StartCoroutine(SpawnWave());
        countdown = timeBetweenWaves;
    }
    if (oleadaActual >= totalOleadas && !endGameStarted)
    {
        endGameStarted = true;
        StartCoroutine(EndGame());
    }
}

private IEnumerator EndGame()
{
    yield return new WaitForSeconds(45f); // Espera 45 segundos (ajusta el tiempo que quieras)
    Debug.Log("Fin del juego");
    pauseMenu.FinalizarJuego(); // Llama al método para finalizar el juego
}

    private IEnumerator SpawnWave()
    {

        for (int i = 0; i < enemigosPorOleada * (oleadaActual + 1); i++)
        {
            GameObject enemigo = pool.GetObject(); // Obtener un enemigo del pool.

            if (enemigo != null)
            {
                enemigo.transform.position = spawnPoint.position;
                enemigo.transform.rotation = spawnPoint.rotation;

                // Reinicia el waypoint del enemigo
                MovimientoEnemigo mov = enemigo.GetComponent<MovimientoEnemigo>();
                if (mov != null)
                    mov.ReiniciarWaypoints();
            }

            yield return new WaitForSeconds(delayEntreEnemigos); // Esperar antes de generar el siguiente enemigo.
        }

        oleadaActual++; // Incrementar el contador de oleadas.

        if (oleadaActual >= totalOleadas)
        {
            Debug.Log("Todas las oleadas han sido generadas.");
        }
    }

}