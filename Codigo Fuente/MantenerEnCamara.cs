using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class MantenerEnCamara : MonoBehaviour
{
    private float minX, maxX, minY, maxY;
    private float anchoSprite, altoSprite;

    void Start()
    {
        // Obtener dimensiones del sprite
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            anchoSprite = sr.bounds.size.x / 2f;  // mitad del ancho
            altoSprite = sr.bounds.size.y / 2f;   // mitad del alto
        }

        // Limites de la cámara
        Camera cam = Camera.main;
        Vector3 esquinaInferiorIzquierda = cam.ViewportToWorldPoint(new Vector3(0, 0, transform.position.z - cam.transform.position.z));
        Vector3 esquinaSuperiorDerecha = cam.ViewportToWorldPoint(new Vector3(1, 1, transform.position.z - cam.transform.position.z));

        minX = esquinaInferiorIzquierda.x + anchoSprite;
        minY = esquinaInferiorIzquierda.y + altoSprite;
        maxX = esquinaSuperiorDerecha.x - anchoSprite;
        maxY = esquinaSuperiorDerecha.y - altoSprite;
    }

    void LateUpdate()
    {
        // Limitar posición
        float x = Mathf.Clamp(transform.position.x, minX, maxX);
        float y = Mathf.Clamp(transform.position.y, minY, maxY);

        transform.position = new Vector3(x, y, transform.position.z);
    }
}
