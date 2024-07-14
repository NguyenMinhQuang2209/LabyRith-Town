using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float speed = 0.1f;
    private Vector3 velocity = Vector3.zero;
    [SerializeField] private Transform player;

    // Background bounds
    [SerializeField] private SpriteRenderer background;

    private float minX, maxX, minY, maxY;
    private float desiredCameraYOffset = 2.5f;

    void Start()
    {
        // Ensure the camera size is adjusted at the start
        AdjustCameraSize();
        CalculateCameraBounds();
    }
    void LateUpdate()
    {
        // Calculate the target position based on the player's position and desired offset
        Vector3 targetPosition = new Vector3(player.position.x, player.position.y + desiredCameraYOffset, transform.position.z);

        // Clamp the target position within the boundaries
        targetPosition.x = Mathf.Clamp(targetPosition.x, minX, maxX);
        targetPosition.y = Mathf.Clamp(targetPosition.y, minY, maxY);

        // Smoothly move the camera to the target position
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, speed);
    }
    void Update()
    {
        // Adjust the camera size based on the current screen size
        AdjustCameraSize();
        CalculateCameraBounds();

        // Get the target position based on the player's position
        Vector3 targetPosition = new Vector3(player.position.x, player.position.y + desiredCameraYOffset, transform.position.z);

        // Clamp the target position within the boundaries
        targetPosition.x = Mathf.Clamp(targetPosition.x, minX, maxX);
        targetPosition.y = Mathf.Clamp(targetPosition.y, minY, maxY);

        // Smoothly move the camera to the target position
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, speed * Time.deltaTime);
    }

    void AdjustCameraSize()
    {
        // Calculate the current aspect ratio
        float windowAspect = (float)Screen.width / (float)Screen.height;
        float targetAspect = 1920f / 1080f; // Replace with your designed aspect ratio

        // Adjust the orthographic size based on the target aspect ratio
        Camera.main.orthographicSize = 5f * (targetAspect / windowAspect); // Adjust 5f to fit your game's design
    }

    void CalculateCameraBounds()
    {
        // Get the size of the background
        float backgroundWidth = background.bounds.size.x;
        float backgroundHeight = background.bounds.size.y;

        // Get the camera dimensions
        float camHeight = Camera.main.orthographicSize * 2;
        float camWidth = camHeight * Camera.main.aspect;

        // Calculate the boundaries
        minX = background.bounds.min.x + camWidth / 2;
        maxX = background.bounds.max.x - camWidth / 2;
        minY = background.bounds.min.y + camHeight / 2;
        maxY = background.bounds.max.y - camHeight / 2;
    }
}
