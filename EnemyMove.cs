using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float speed = 2f;
    public Transform pointA;
    public Transform pointB;

    private bool keKanan = true;

    void Update()
    {
        if (pointA == null || pointB == null) return;

        if (keKanan)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;

            if (transform.position.x >= pointB.position.x)
            {
                keKanan = false;
                Flip();
            }
        }
        else
        {
            transform.position += Vector3.left * speed * Time.deltaTime;

            if (transform.position.x <= pointA.position.x)
            {
                keKanan = true;
                Flip();
            }
        }
    }

    void Flip()
    {
        Vector3 s = transform.localScale;
        s.x *= -1;
        transform.localScale = s;
    }
}