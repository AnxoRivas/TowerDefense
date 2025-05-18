using UnityEngine;

public class TalarYDestruir : MonoBehaviour
{
    public Mesh meshTalado; // Mesh que se aplica al talar
    private bool talado = false;

    [SerializeField] private GameManager gameManager; // Referencia al GameManager

    [SerializeField] private AudioClip sonidoTalar; // Clip de sonido para el talado
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();
    }

    public void ReproducirSonidoTalar(float volumen = 0.1f)
    {
        if (sonidoTalar != null && audioSource != null)
            audioSource.PlayOneShot(sonidoTalar, volumen);
    }

    public void TalarODestruir()
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
            meshFilter.mesh = meshTalado;
            talado = true;
            gameManager.SumarRecursos(10);
            ReproducirSonidoTalar(0.1f);
        }
        else if (meshFilter.sharedMesh == meshTalado)
        {
            Debug.Log("Destruir: " + gameObject.name);

            // Restaurar cursor antes de destruir el objeto
            CursorManager cursorManager = FindFirstObjectByType<CursorManager>();
            if (cursorManager != null)
                cursorManager.SetDefaultCursor();

            Destroy(gameObject);
            gameManager.SumarRecursos(5);
            ReproducirSonidoTalar(0.1f);
        }
    }

    // --- Cambia el cursor al pasar el mouse por encima del árbol ---
    private void OnMouseEnter()
    {
        CursorManager cursorManager = FindFirstObjectByType<CursorManager>();
        if (cursorManager != null)
            cursorManager.SetAxeCursor();
    }

    private void OnMouseExit()
    {
        CursorManager cursorManager = FindFirstObjectByType<CursorManager>();
        if (cursorManager != null)
            cursorManager.SetDefaultCursor();
    }
}
