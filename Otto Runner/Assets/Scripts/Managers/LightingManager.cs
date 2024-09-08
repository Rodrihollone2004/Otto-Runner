using UnityEngine;

public class LightingManager : MonoBehaviour
{
    [SerializeField] private Light sceneLight; // Referencia a la luz de la escena

    [SerializeField] private Color normalLightColor = Color.white; // Color normal de la luz
    [SerializeField] private Color darkLightColor = Color.gray;    // Color oscuro de la luz

    [SerializeField] private float changeInterval = 1000f; // Distancia para alternar colores

    private DistanceCounter distanceCounter;

    void Start()
    {
        GameObject gameManager = GameObject.Find("GameManager"); 
        if (gameManager != null)
        {
            distanceCounter = gameManager.GetComponent<DistanceCounter>();
            if (distanceCounter == null)
            {
                Debug.LogError("No se encontró el componente DistanceCounter en el GameManager.");
            }
        }
    }

    void Update()
    {
        if (distanceCounter != null && sceneLight != null)
        {
            float distance = distanceCounter.GetDistance();
            AdjustLighting(distance);
        }
    }

    private void AdjustLighting(float distance)
    {
        float cyclePosition = Mathf.Floor(distance / changeInterval) % 2;

        if (cyclePosition == 0)
        {
            sceneLight.color = normalLightColor;
        }
        else
        {
            sceneLight.color = darkLightColor;
        }
    }
}
