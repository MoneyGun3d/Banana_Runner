using UnityEngine;

public class MoverNubes : MonoBehaviour
{
    public float velocidad = 1f;

    void Update()
    {
        // Mover hacia la izquierda
        transform.Translate(Vector3.left * velocidad * Time.deltaTime);

        // Destruir si sale de la pantalla
        if (transform.position.x < Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x - 2f)
        {
            Destroy(gameObject);
        }
    }
}
