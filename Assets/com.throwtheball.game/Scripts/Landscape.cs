using System.Collections;
using UnityEngine;

public class Landscape : MonoBehaviour
{
    private GameObject LandscapeRectanglePrefab { get; set; }

    private void Awake()
    {
        LandscapeRectanglePrefab = Resources.Load<GameObject>("Landscape Rectangle");
    }

    private IEnumerator Start()
    {
        while(true)
        {
            Instantiate(LandscapeRectanglePrefab, transform);
            yield return new WaitForSeconds(Random.Range(1.35f, 2.0f));
        }
    }
}
