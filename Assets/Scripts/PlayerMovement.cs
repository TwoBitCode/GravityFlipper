using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Movement speed

    void Update()
    {
        // Get input from the keyboard (A/D or Left/Right arrow keys)
        float move = Input.GetAxis("Horizontal");

        // Move the player left and right
        transform.Translate(new Vector3(move, 0, 0) * speed * Time.deltaTime);

        // Lock the player's rotation
        transform.rotation = Quaternion.identity;
    }
}
