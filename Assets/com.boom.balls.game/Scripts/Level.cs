using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour
{
    private bool IsReady { get; set; }
    private bool IsCute { get; set; }

    private Vector2 velocity = Vector2.zero;
    private const float smoothTime = 0.35f;

    [SerializeField] Rigidbody2D ball;

    private void Start()
    {
        transform.position = new Vector3(0, 13.0f);
    }

    private void Update()
    {
        if(IsReady)
        {
            return;
        }

        transform.position = Vector2.SmoothDamp(transform.position, Vector2.zero, ref velocity, smoothTime);
        if(Vector2.Distance(transform.position, Vector2.zero) < 1.0f)
        {
            IsReady = true;
        }
    }

    public void Cute()
    {
        if(!IsReady || IsCute)
        {
            return;
        }

        IsCute = true;
        ball.AddForce(Vector2.up * 20, ForceMode2D.Impulse);
        StartCoroutine(nameof(ClearMe));
    }

    private IEnumerator ClearMe()
    {
        yield return new WaitForSeconds(1.55f);
        while (transform.position.y > -3.0f)
        {
            transform.position = Vector2.MoveTowards(transform.position, Vector2.down * 3.0f, 15.0f * Time.deltaTime);
            yield return null;
        }

        GameManager.Instance.InitLevel();
        Destroy(gameObject);
    }
}
