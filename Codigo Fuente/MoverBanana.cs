using UnityEngine;
using UnityEngine.InputSystem;

public class MoverBanana : MonoBehaviour
{
    [SerializeField]
    private float velocidadHorizontal = 10f;
    [SerializeField]
    private float velocidadVertical = 10f;

    private Vector2 direccion;

    void Update()
    {
        direccion = Vector2.zero;

        // Movimiento vertical
        if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed)
        {
            direccion += Vector2.up;
        }
        if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed)
        {
            direccion += Vector2.down;
        }

        // Movimiento horizontal
        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
        {
            direccion += Vector2.left;
        }
        if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
        {
            direccion += Vector2.right;
        }

        // Normalizar para no ir más rápido en diagonal
        if (direccion.magnitude > 1f) direccion.Normalize();

        // Aplicar movimiento
        Vector3 movimiento = new Vector3(direccion.x * velocidadHorizontal, direccion.y * velocidadVertical, 0f);
        transform.position += movimiento * Time.deltaTime;
    }


}
