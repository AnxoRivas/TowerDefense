using System.Collections.Generic;
using UnityEngine;

public class ProyectilPool : MonoBehaviour
{
    [SerializeField] private GameObject proyectilPrefab;
    [SerializeField] private int poolSize = 10;

    private List<GameObject> pool = new List<GameObject>();

    void Awake()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(proyectilPrefab);
            obj.SetActive(false);
            pool.Add(obj);
        }
    }

    public GameObject GetProyectil()
    {
        foreach (GameObject obj in pool)
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
            }
        }
        // Si no hay proyectiles disponibles, puedes expandir el pool o devolver null
        GameObject objNew = Instantiate(proyectilPrefab);
        objNew.SetActive(false);
        pool.Add(objNew);
        objNew.SetActive(true);
        return objNew;
    }
}
