using UnityEngine;

public class SimpleMove2D : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector2 direction = new Vector2(x, y).normalized;
        transform.position += (Vector3)(direction * moveSpeed * Time.deltaTime);
    }
}