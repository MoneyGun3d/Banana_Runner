using UnityEngine;

public class SpawnerMonos : MonoBehaviour
{
    public GameObject[] monos;        
    public float intervaloInicial = 3f;      // tiempo inicial entre monos
    public float yMin = -3f;
    public float yMax = 3f;
    public float distanciaDerecha = 2f;

    [Header("Dificultad")]
    public float velocidadInicial = -2f;      // velocidad inicial de los monos
    public float incrementoVelocidad = -0.2f; // cada mono nuevo es más rápido
    public float decrementoIntervalo = 0.05f; // cada mono nuevo aparece más rápido
    public float intervaloMinimo = 0.5f;      // límite mínimo del intervalo

    private float velocidadActual;
    private float intervaloActual;
    private float timer = 0f;

    void Start()
    {
        velocidadActual = velocidadInicial;
        intervaloActual = intervaloInicial;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= intervaloActual)
        {
            GenerarMono();
            timer = 0f;

            // aumentar velocidad para el siguiente mono
            velocidadActual += incrementoVelocidad;

            // disminuir intervalo para el siguiente spawn
            intervaloActual = Mathf.Max(intervaloMinimo, intervaloActual - decrementoIntervalo);
        }
    }

    void GenerarMono()
    {
        if (monos.Length == 0) return;

        // Mono random
        GameObject monoPrefab = monos[Random.Range(0, monos.Length)];

        // Posición de spawn
        Vector3 pos = Camera.main.ViewportToWorldPoint(new Vector3(1, 0.5f, 0));
        pos.x += distanciaDerecha;
        pos.y = Random.Range(yMin, yMax);
        pos.z = 0;

        // Instanciar
        GameObject mono = Instantiate(monoPrefab, pos, monoPrefab.transform.rotation);

        // Movimiento
        MoverMonos mover = mono.AddComponent<MoverMonos>();
        mover.velocidad = velocidadActual;
    }
}
