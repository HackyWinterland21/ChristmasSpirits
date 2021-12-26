using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostPosition : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float minDist;
    private Vector3 originalPosition;
    private Rigidbody2D rb2D;
    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(transform.position, originalPosition);
        rb2D.velocity = new Vector3(0, 0, 0);

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
