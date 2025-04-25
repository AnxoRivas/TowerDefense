using UnityEngine;

public class TalarYDestruir : MonoBehaviour
{
    public Mesh meshTalado; // Mesh que se aplica al talar
    private bool talado = false;

    void OnMouseDown()
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>();

        if (meshFilter == null) return;

        if (!talado)
        {
            // Primer clic: talar (cambiar mesh)
            meshFilter.mesh = meshTalado;
            talado = true;
        }
        else if (meshFilter.sharedMesh == meshTalado)
        {
            // Segundo clic: destruir
            Destroy(gameObject);
        }
    }
}
