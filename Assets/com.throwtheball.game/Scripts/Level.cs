using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour
{
    private bool IsReady { get; set; }

    private Vector2 velocity = Vector2.zero;
    private const float smoothTime = 0.35f;

    [SerializeField] FixedJoint2D fixedJoint;
    [SerializeField] GameObject pivot;
    [SerializeField] GameObject basket;

    private void Start()
    {
        transform.position = new Vector3(0, 13.0f);
        basket.transform.localPosition = new Vector2(Random.Range(-1.0f, 1.0f), -3.29f);
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
        if(!IsReady || !fixedJoint.connectedBody)
        {
            return;
        }

        fixedJoint.connectedBody.transform.SetParent(transform);
        fixedJoint.connectedBody.velocity = Vector2.zero;
        fixedJoint.connectedBody = null;

        pivot.SetActive(false);
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
