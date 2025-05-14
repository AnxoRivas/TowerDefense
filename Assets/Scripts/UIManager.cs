using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI text; // Referencia al TextMeshPro.
    [SerializeField] GameObject vida1; // Referencia a los objetos de vida.
    [SerializeField] GameObject vida2; // Referencia a los objetos de vida.
    [SerializeField] GameObject vida3; // Referencia a los objetos de vida.
    [SerializeField] GameManager gameManager; // Referencia al GameManager. 

 void Awake()
{

    gameManager = GameManager.Instance; // Asigna la instancia del GameManager.
    if (gameManager == null)
    {
        Debug.LogError("GameManager no encontrado.");
    }

    Debug.Log($"vida1: {vida1}, vida2: {vida2}, vida3: {vida3}");
}
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestarVida()
    {
        gameManager.RestarVida(); // Llama al método RestarVida del GameManager.

        // Desactiva los objetos de vida según la cantidad de vidas restantes.
        switch (gameManager.vidas)
        {
            case 2:
                if (vida3 != null) vida3.SetActive(false);
                break;
            case 1:
                if (vida2 != null) vida2.SetActive(false);
                break;
            case 0:
                if (vida1 != null) vida1.SetActive(false);
                break;
        }
    }

    public void ActualizarTexto()
    {
        if (text != null)
        {
            text.text = gameManager.recursos.ToString(); // Actualiza el texto con la cantidad de recursos.
        }
        else
        {
            Debug.LogError("El componente TextMeshProUGUI no está asignado.");
        }
    }
}
