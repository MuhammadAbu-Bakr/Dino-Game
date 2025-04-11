using UnityEngine;

public class Ground_script : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    public float speed = 0.1f;
    public float maxSpeed = 5f;
    public float accelerationRate = 0.1f; // How fast the speed increases
    private Vector2 textureOffset;
    private Material groundMaterial;
    private float timeSurvived = 0f;

    void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        groundMaterial = meshRenderer.sharedMaterial;
        textureOffset = groundMaterial.mainTextureOffset;
    }

    void Update()
    {
        // Increase speed over time
        timeSurvived += Time.deltaTime;
        float currentSpeed = Mathf.Min(speed + (timeSurvived * accelerationRate), maxSpeed);
        
        textureOffset.x += currentSpeed * Time.deltaTime;
        textureOffset.x %= 0.5f; 
        groundMaterial.mainTextureOffset = textureOffset;
    }
}