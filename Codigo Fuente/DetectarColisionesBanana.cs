using UnityEngine;

public class DetectarColisionesBanana : MonoBehaviour
{
    public HUDManager hud;                  // Asignar en inspector o buscar automáticamente
    public ParticleSystem explosionPrefab;  // Prefab de partículas al morir

    void Start()
    {
        if (hud == null)
        {
            hud = Object.FindFirstObjectByType<HUDManager>();
            if (hud == null)
            {
                Debug.LogError("No se encontró HUDManager en la escena");
            }
        }
    }

    void OnTriggerEnter2D(Collider2D hitbox)
    {
        if (hud == null) return;

        // Colisión con Mono
        if (hitbox.gameObject.CompareTag("mono"))
        {
            // Perder vida mediante HUDManager
            hud.PerderVida(1);

            ParticleSystem ps = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            ps.Play();

            // Partículas de la banana al morir
            if (hud.vidas <= 0)
            {
                Destroy(gameObject);
            }

            
        }

        // Colisión con Bananita
        if (hitbox.gameObject.CompareTag("bananita"))
        {
            hud.GanarPuntos(10);
            Destroy(hitbox.gameObject);
        }

        // Desactivar collider para evitar múltiples triggers
        Collider2D col = hitbox.gameObject.GetComponent<Collider2D>();
        if (col != null)
            col.enabled = false;
    }
}
