using UnityEngine;

public class SpawnerNubes : MonoBehaviour
{
    [Header("Prefabs de nubes")]
    public GameObject[] nubes;

    [Header("Spawn")]
    public float intervalo = 2f;
    public float yMin = -5f;
    public float yMax = 5f;
    public float distanciaDerecha = 2f;

    [Header("Movimiento")]
    public float velocidadMin = 1f;
    public float velocidadMax = 3f;

    void Start()
    {
        InvokeRepeating("GenerarNube", 0f, intervalo);
    }

    void GenerarNube()
    {
        if (nubes.Length == 0) return;

        // Elegir un prefab random
        GameObject nubePrefab = nubes[Random.Range(0, nubes.Length)];

        // Calcular la posición fuera de cámara a la derecha
        Vector3 posDerecha = Camera.main.ViewportToWorldPoint(new Vector3(1, 0.5f, 0));
        posDerecha.x += distanciaDerecha;
        posDerecha.y = Random.Range(yMin, yMax);
        posDerecha.z = 0;

        // Instanciar
        GameObject nube = Instantiate(nubePrefab, posDerecha, Quaternion.identity);

        // Añadir movimiento hacia la izquierda
        float vel = Random.Range(velocidadMin, velocidadMax);
        nube.AddComponent<MoverNubes>().velocidad = vel;
    }
}

