using UnityEngine;
using UnityEngine.EventSystems;

public class TowerPlacementManager : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject towerPrefab; // Prefab de la torre
    [SerializeField] private LayerMask placementLayerMask; // Capa donde se puede colocar la torre
    [SerializeField] private LayerMask collisionLayerMask; // Capa para verificar colisiones
    [SerializeField] private Material validPlacementMaterial; // Material para preview válido
    [SerializeField] private Material invalidPlacementMaterial; // Material para preview inválido

    private GameObject currentPreview; // Torre en preview
    private GameObject selectedTowerPrefab; // Torre seleccionada
    private bool isPlacing = false; // Indica si se está colocando una torre

    void Update()
    {
        if (isPlacing)
        {
            HandlePlacementPreview();

            // Confirmar colocación con clic izquierdo
            if (Input.GetMouseButtonDown(0))
            {
                PlaceTower();
            }

            // Cancelar colocación con clic derecho
            if (Input.GetMouseButtonDown(1))
            {
                CancelPlacement();
            }
        }
    }

    // Método de la interfaz IPointerClickHandler para detectar clics en el botón o imagen
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Botón clicado: Seleccionando torre...");
        selectedTowerPrefab = towerPrefab; // Asigna el prefab de la torre seleccionada
        StartPlacement();
    }

    private void StartPlacement()
    {
        if (selectedTowerPrefab == null) return;

        // Crear el preview de la torre
        currentPreview = Instantiate(selectedTowerPrefab);
        SetLayer(currentPreview, LayerMask.NameToLayer("Preview")); // Cambia la capa del preview
        currentPreview.GetComponent<Collider>().enabled = false; // Desactiva el collider del preview
        SetPreviewMaterial(validPlacementMaterial);
        isPlacing = true;
    }

    private void SetLayer(GameObject obj, int newLayer)
    {
        // Cambia el Layer de un GameObject y sus hijos
        if (obj == null) return;
        obj.layer = newLayer;
        foreach (Transform child in obj.transform)
        {
            if (child == null) continue;
            SetLayer(child.gameObject, newLayer);
        }
    }

    private void HandlePlacementPreview()
    {
        // Obtener la posición del mouse en el mundo
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, placementLayerMask))
        {
            currentPreview.transform.position = hit.point; // Actualiza la posición del preview

            // Verificar colisiones
            if (IsPlacementValid())
            {
                SetPreviewMaterial(validPlacementMaterial);
            }
            else
            {
                SetPreviewMaterial(invalidPlacementMaterial);
            }
        }
    }

    private bool IsPlacementValid()
    {
        // Obtén el colisionador del GameObject hijo
        Collider placementCollider = currentPreview.GetComponentInChildren<Collider>();

        if (placementCollider == null)
        {
            Debug.LogError("No se encontró un Collider para la validación de colocación.");
            return false;
        }

        Collider[] colliders = Physics.OverlapBox(
            placementCollider.bounds.center,
            placementCollider.bounds.extents,
            Quaternion.identity,
            collisionLayerMask
        );

        foreach (var col in colliders)
        {
            if (col != placementCollider)
                return false; // Hay otra colisión
        }
        return true; // Solo está el preview

        //return colliders.Length == 0; // Es válido si no hay colisiones
    }

    private void SetPreviewMaterial(Material material)
    {
        Renderer[] renderers = currentPreview.GetComponentsInChildren<Renderer>();
        foreach (Renderer renderer in renderers)
        {
            renderer.material = material;
        }
    }

    private void PlaceTower()
    {
        if (IsPlacementValid())
        {
            // Colocar la torre en la posición actual del preview
            Instantiate(selectedTowerPrefab, currentPreview.transform.position, Quaternion.identity);
            CancelPlacement();
            isPlacing = false; // Asegúrate de que isPlacing sea false después de colocar la torre
        }
        else
        {
            Debug.Log("No se puede colocar la torre aquí.");
        }
    }

    private void CancelPlacement()
    {
        if (currentPreview != null)
        {
            Destroy(currentPreview);
        }
        isPlacing = false;
    }
}