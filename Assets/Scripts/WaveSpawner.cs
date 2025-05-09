using UnityEngine;
using System.Collections;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private ObjectPool pool; // Referencia al Object Pool.
    [SerializeField] private Transform spawnPoint; // Punto de aparición de los magos.
    [SerializeField] private float timeBetweenWaves = 5f; // Tiempo entre oleadas.
    [SerializeField] private int magosPorOleada = 5; // Número de magos por oleada.
    [SerializeField] private int totalOleadas = 3; // Número total de oleadas.
    [SerializeField] private float delayEntreMagos = 0.5f; // Tiempo entre la aparición de cada mago.

    private int oleadaActual = 0; // Contador de oleadas.
    private float countdown = 15f;

    private void Update()
    {
        if (oleadaActual >= totalOleadas)
        {
            Debug.Log("Todas las oleadas han sido generadas.");
            return; // Si se han generado todas las oleadas, no hacer nada.
        }

        countdown -= Time.deltaTime;

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave()); // Iniciar la corrutina para generar la oleada.
            countdown = timeBetweenWaves;
        }
    }

    private IEnumerator SpawnWave()
    {
        Debug.Log($"Generando oleada {oleadaActual + 1}...");

        for (int i = 0; i < magosPorOleada; i++)
        {
            GameObject mago = pool.GetObject(); // Obtener un mago del pool.

            if (mago != null)
            {
                mago.transform.position = spawnPoint.position; // Posicionarlo en el punto de aparición.
                mago.transform.rotation = spawnPoint.rotation; // Ajustar su rotación.
            }

            yield return new WaitForSeconds(delayEntreMagos); // Esperar antes de generar el siguiente mago.
        }

        Debug.Log($"Oleada {oleadaActual + 1} generada.");
        oleadaActual++; // Incrementar el contador de oleadas.

        if (oleadaActual >= totalOleadas)
        {
            Debug.Log("Todas las oleadas han sido generadas.");
        }
    }
}