using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostPosition : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float minDist;
    private Vector3 originalPosition;
    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(transform.position, originalPosition);

        if (dist < minDist)
        {
            transform.position = originalPosition;
        } else
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, originalPosition, step);
        }
    }
}
