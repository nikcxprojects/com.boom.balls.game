using UnityEngine;

public class Goal : MonoBehaviour
{
    private float Speed { get; set; }
    private float TargetX { get; set; }

    private Trigger Trigger { get; set; }

    private void Awake()
    {
        Trigger = GetComponent<Trigger>();
    }

    private void Start()
    {
        Speed = Random.Range(2.0f, 10.0f);
        TargetX = Random.Range(0, 100) > 50 ? -1.7f : 1.7f;

        transform.localPosition = new Vector2(TargetX,  Random.Range(-3.0f, 1.5f));
    }

    private void Update()
    {
        if(Trigger.IsCollided)
        {
            return;
        }

        transform.localPosition = Vector2.MoveTowards(transform.localPosition, new Vector2(-TargetX, transform.localPosition.y), Speed * Time.deltaTime);
        if(transform.localPosition.x == -TargetX)
        {
            TargetX *= -1;
        }
    }
}
