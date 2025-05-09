using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject prefabMago; // Prefab del objeto a instanciar (Mago).
    [SerializeField] private GameObject prefabRogue; // Prefab del objeto a instanciar (Rogue).
    [SerializeField] private int poolSize = 10; // Tamaño inicial del pool.

    private List<GameObject> pool = new List<GameObject>();

    private void Start()
    {
        if (prefabMago == null || prefabRogue == null)
        {
        Debug.LogError("Los prefabs no están asignados en el ObjectPool.");
        return;
        }
        // Crear el pool inicial de objetos.
        for (int i = 0; i < poolSize; i++)
        {
            
            GameObject obj = Instantiate(Random.Range(0, 2) == 0 ? prefabMago : prefabRogue);
            obj.SetActive(false); // Desactivar el objeto inicialmente.
            pool.Add(obj);
        }
    }

    // Obtener un objeto del pool.
    public GameObject GetObject()
    {
        foreach (GameObject obj in pool)
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true); // Activar el objeto.
                return obj;
            }
        }

        // Si no hay objetos disponibles, devolver null.
        return null;
    }

    // Devolver un objeto al pool.
    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false); // Desactivar el objeto.
    }
}
