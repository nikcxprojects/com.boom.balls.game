using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour
{
    private bool IsReady { get; set; }

    private Vector2 velocity = Vector2.zero;
    private const float smoothTime = 0.35f;

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
        if(!IsReady)
        {
            return;
        }

        Debug.Log("cute");
        StartCoroutine(nameof(ClearMe));
    }

    private IEnumerator ClearMe()
    {
        yield return new WaitForSeconds(1.75f);
        while (transform.position.y > -3.0f)
        {
            transform.position = Vector2.MoveTowards(transform.position, Vector2.down * 3.0f, 10.0f * Time.deltaTime);
            yield return null;
        }

        GameManager.Instance.InitLevel();
        Destroy(gameObject);
    }
}
