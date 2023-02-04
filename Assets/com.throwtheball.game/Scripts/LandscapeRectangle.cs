using UnityEngine;

public class LandscapeRectangle : MonoBehaviour
{
    private const float speed = 3.0f;

    private int Direction { get; set; }

    private void Awake()
    {
        Destroy(gameObject, 4.0f);
    }

    private void Start()
    {
        Direction = Random.Range(0, 100) > 50 ? 1 : -1;

        float x = Direction * 458;
        float y = Random.Range(-370.0f, 370.0f);

        transform.localPosition = new Vector2(x, y);
    }

    private void Update()
    {
        transform.Translate(Direction * speed * Time.deltaTime * Vector2.left);
    }
}
