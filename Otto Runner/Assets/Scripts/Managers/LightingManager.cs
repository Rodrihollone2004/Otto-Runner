using UnityEngine;

public class LightingManager : MonoBehaviour
{
    [SerializeField] private Light sceneLight; // Referencia a la luz de la escena
    [SerializeField] private Light[] spotLights; // Referencia a los spotlights a activar/desactivar

    [SerializeField] private Color normalLightColor = Color.white; // Color normal de la luz
    [SerializeField] private Color darkLightColor = Color.gray;    // Color oscuro de la luz

    [SerializeField] private float changeInterval = 1000f; // Distancia para alternar colores

    [SerializeField] private Material normalSkybox; // Skybox normal
    [SerializeField] private Material darkSkybox;   // Skybox oscuro

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

        // Establecer el skybox inicial
        RenderSettings.skybox = normalSkybox;
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
            SetSpotLightsActive(false); // Apagar los spotlights
            RenderSettings.skybox = normalSkybox; // Cambiar al skybox normal
        }
        else
        {
            sceneLight.color = darkLightColor;
            SetSpotLightsActive(true); // Encender los spotlights
            RenderSettings.skybox = darkSkybox; // Cambiar al skybox oscuro
        }
    }

    private void SetSpotLightsActive(bool isActive)
    {
        foreach (Light spotlight in spotLights)
        {
            if (spotlight != null)
            {
                spotlight.enabled = isActive; // Activar o desactivar el spotlight
            }
            else
            {
                Debug.LogWarning("Un spotlight en la lista es nulo.");
            }
        }
    }
}
