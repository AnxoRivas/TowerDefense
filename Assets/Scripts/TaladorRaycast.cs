using UnityEngine;

public class TaladorRaycast : MonoBehaviour
{
    [SerializeField] private LayerMask arbolLayerMask; // Asigna solo la capa "Arbol" en el inspector

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 100f, arbolLayerMask))
            {
                TalarYDestruir talar = hit.collider.GetComponent<TalarYDestruir>();
                if (talar != null)
                {
                    talar.TalarODestruir();
                }
            }
        }
    }
}
