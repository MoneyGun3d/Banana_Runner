using UnityEngine;

public class MoverMonos : MonoBehaviour
{
    public float velocidad = 2f;

    void Update()
    {
        transform.Translate(Vector3.left * velocidad * Time.deltaTime);

        if(transform.position.x < Camera.main.ViewportToWorldPoint(new Vector3(0,0,0)).x - 2f)
        {
            Destroy(gameObject);
        }
    }
}
