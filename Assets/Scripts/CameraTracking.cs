using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraTracking : MonoBehaviour
{
    public GameObject player;
    private CharacterController2D controllerInstance;
    public float smoothTime = .3F; // Smoothness of the camera movement
    private Vector3 currentVelocity = Vector3.zero; // Used by SmoothDamp
    private float previousYPosition;
    

    void Start()
    {
        controllerInstance = FindObjectOfType<CharacterController2D>();
        previousYPosition = player.transform.position.y;

       
    }

    void Update()
    {
       
       

       //Proceed to adjust the camera's position only if the character is not dead
       previousYPosition = player.transform.position.y;
       float targetYPosition = Mathf.Max(player.transform.position.y, transform.position.y);
       if(player.transform.position.y - targetYPosition < -5)
       {
            ReloadScene();
       }
       // Determine the target position for the camera. Only Y is updated for rising effect
       Vector3 targetPosition = new Vector3(transform.position.x, targetYPosition, transform.position.z);

       // Smoothly transition to the target position
       transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, smoothTime);
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
