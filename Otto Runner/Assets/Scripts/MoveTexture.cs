using UnityEngine;

public class MoveTexture : MonoBehaviour
{
    public float speed = 1f; // Velocidad de movimiento, puedes modificarla desde el Inspector

    private Renderer renderer;

    void Start()
    {
        // Obt�n el componente Renderer del objeto
        renderer = GetComponent<Renderer>();

    }

    void Update()
    {
        // Calcula el desplazamiento en funci�n de la velocidad y el tiempo transcurrido
        float movement = speed * Time.deltaTime;

        // Mueve la textura en direcci�n negativa del eje X
        Vector2 offset = new Vector2(0, -movement); // Cambia Vector3 a Vector2
        renderer.material.mainTextureOffset += offset;

        if (GameManger.instance.Dead)
        {
            speed = 0f;
        }
    }
}
