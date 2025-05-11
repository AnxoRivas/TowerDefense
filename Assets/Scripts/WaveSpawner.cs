using UnityEngine;
using System.Collections;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private ObjectPool pool; // Referencia al Object Pool.
    [SerializeField] private Transform spawnPoint; // Punto de aparición de los magos.
    [SerializeField] private float timeBetweenWaves = 5f; // Tiempo entre oleadas.
    [SerializeField] private int enemigosPorOleada = 5; // Número de enemigos por oleada.
    [SerializeField] private int totalOleadas = 3; // Número total de oleadas.
    [SerializeField] private float delayEntreEnemigos = 0.5f; // Tiempo entre la aparición de cada enemigo.

    private int oleadaActual = 0; // Contador de oleadas.
    private float countdown = 15f;

    private void Update()
    {

        countdown -= Time.deltaTime;

        if (countdown <= 0f && oleadaActual < totalOleadas)
        {
            StartCoroutine(SpawnWave()); // Iniciar la corrutina para generar la oleada.
            countdown = timeBetweenWaves;
        }
    }

    private IEnumerator SpawnWave()
    {

        for (int i = 0; i < enemigosPorOleada; i++)
        {
            GameObject enemigo = pool.GetObject(); // Obtener un enemigo del pool.

            if (enemigo != null)
            {
                enemigo.transform.position = spawnPoint.position; // Posicionarlo en el punto de aparición.
                enemigo.transform.rotation = spawnPoint.rotation; // Ajustar su rotación.
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