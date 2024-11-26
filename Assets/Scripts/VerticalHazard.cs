using UnityEngine;

public class VerticalHazard : MonoBehaviour
{
    public float speed = 2f;
    public float minY = -3f;
    public float maxY = 3f;
    private bool movingUp = true;

    void Update()
    {
        if (movingUp)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
            if (transform.position.y >= maxY)
            {
                movingUp = false;
            }
        }
        else
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
            if (transform.position.y <= minY)
            {
                movingUp = true;
            }
        }
    }
}
