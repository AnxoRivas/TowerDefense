using UnityEngine;

public class TalarYDestruir : MonoBehaviour
{
    public Mesh meshTalado; // Mesh que se aplica al talar
    private bool talado = false;

    [SerializeField] private GameManager gameManager; // Referencia al GameManager

void OnMouseDown()
{
    Debug.Log("Clic detectado en: " + gameObject.name);

    MeshFilter meshFilter = GetComponent<MeshFilter>();

    if (meshFilter == null)
    {
        Debug.LogWarning("El objeto no tiene un MeshFilter: " + gameObject.name);
        return;
    }

    if (!talado)
    {
        Debug.Log("Talar: " + gameObject.name);
        // Primer clic: talar (cambiar mesh)
        meshFilter.mesh = meshTalado;
        talado = true;
        gameManager.SumarRecursos(10); // Sumar recursos al GameManager
    }
    else if (meshFilter.sharedMesh == meshTalado)
    {
        Debug.Log("Destruir: " + gameObject.name);
        // Segundo clic: destruir
        Destroy(gameObject);
        gameManager.SumarRecursos(5); // Sumar recursos al GameManager
    }
}
}
