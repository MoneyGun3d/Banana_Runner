using UnityEngine;
using UnityEngine.UIElements;

public class HUDManager : MonoBehaviour
{
    [Header("UI Documents")]
    public UIDocument hudDocument;        // HUD normal (vidas y puntos)
    public UIDocument gameOverDocument;   // Panel de Game Over

    private Label vidasLabel;
    private Label puntosLabel;
    private Label gameOverLabel;

    [Header("Stats")]
    public int vidas = 3;
    public int puntos = 0;

    void Awake()
    {
        // HUD normal
        if (hudDocument != null)
        {
            var rootHUD = hudDocument.rootVisualElement;
            vidasLabel = rootHUD.Q<Label>("VidasLabel");
            puntosLabel = rootHUD.Q<Label>("PuntosLabel");

            if (vidasLabel == null) Debug.LogError("No se encontró VidasLabel en HUD");
            if (puntosLabel == null) Debug.LogError("No se encontró PuntosLabel en HUD");
        }
        else
        {
            Debug.LogError("hudDocument no asignado en HUDManager");
        }

        // Game Over UI
        if (gameOverDocument != null)
        {
            var rootGO = gameOverDocument.rootVisualElement;
            gameOverLabel = rootGO.Q<Label>("Texto");

            if (gameOverLabel == null) Debug.LogError("No se encontró Label 'Texto' en Game Over UI");

            // Ocultar Game Over al inicio
            gameOverDocument.rootVisualElement.style.display = DisplayStyle.None;
        }
        else
        {
            Debug.LogError("gameOverDocument no asignado en HUDManager");
        }

        ActualizarHUD();
    }

    /// <summary>Disminuye vidas y actualiza HUD</summary>
    public void PerderVida(int cantidad = 1)
    {
        vidas -= cantidad;
        if (vidas < 0) vidas = 0;

        ActualizarHUD();

        if (vidas == 0)
            MostrarGameOver();
    }

    /// <summary>Aumenta puntos y actualiza HUD</summary>
    public void GanarPuntos(int cantidad = 10)
    {
        puntos += cantidad;
        ActualizarHUD();
    }

    private void ActualizarHUD()
    {
        if (vidasLabel != null)
            vidasLabel.text = "Vidas\n" + new string('♥', vidas);

        if (puntosLabel != null)
            puntosLabel.text = "Puntos: " + puntos;
    }

    private void MostrarGameOver()
    {
        if (gameOverLabel != null)
            gameOverLabel.text = $"Game Over\nPuntos: {puntos}";

        if (gameOverDocument != null)
            gameOverDocument.rootVisualElement.style.display = DisplayStyle.Flex;

        Debug.Log("Game Over!");
    }
}
