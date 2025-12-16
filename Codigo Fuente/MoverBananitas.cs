using UnityEngine;

public class MoverBananitas : MonoBehaviour
{
    public float velocidad = 2f;

    void Update()
    {
        // Mover hacia la izquierda
        transform.Translate(Vector3.left * velocidad * Time.deltaTime);

        // Destruir si sale de la pantalla por la izquierda
        if (transform.position.x < Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x - 2f)
        {
            Destroy(gameObject);
        }
    }
}
