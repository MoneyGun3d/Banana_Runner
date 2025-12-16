using UnityEngine;

public class SpawnerBananitas : MonoBehaviour
{
    [Header("Prefabs de Bananitas")]
    public GameObject[] bananitas;

    [Header("Spawn")]
    public float intervalo = 2f;         // tiempo fijo entre cada bananita
    public float yMin = -4.5f;
    public float yMax = 4.5f;
    public float distanciaDerecha = 2f;

    [Header("Movimiento")]
    public float velocidad = 2f;         // velocidad fija hacia la izquierda

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= intervalo)
        {
            GenerarBananita();
            timer = 0f;
        }
    }

    void GenerarBananita()
    {
        if (bananitas.Length == 0) return;

        // Elegir un prefab aleatorio
        GameObject bananitaPrefab = bananitas[Random.Range(0, bananitas.Length)];

        // Posición de spawn fuera de la cámara a la derecha
        Vector3 pos = Camera.main.ViewportToWorldPoint(new Vector3(1, 0.5f, 0));
        pos.x += distanciaDerecha;
        pos.y = Random.Range(yMin, yMax);
        pos.z = 0;

        // Instanciar
        GameObject bananita = Instantiate(bananitaPrefab, pos, bananitaPrefab.transform.rotation);

        // Añadir movimiento hacia la izquierda
        MoverBananitas mover = bananita.AddComponent<MoverBananitas>();
        mover.velocidad = velocidad;
    }
}
