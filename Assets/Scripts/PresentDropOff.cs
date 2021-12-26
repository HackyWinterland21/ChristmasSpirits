using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PresentDropOff : MonoBehaviour
{
    [SerializeField] private int numPresentsReq;
    private int numPresentsDetected;

    void Start()
    {
        numPresentsDetected = 0;    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "grabbable")
        {
            numPresentsDetected++;
            print("plus 1");
            if (numPresentsDetected == numPresentsReq)
            {
                StartCoroutine(nextHouse());
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "grabbable")
        {
            numPresentsDetected--;
            print("minus 1");
        }
    }
    private IEnumerator nextHouse()
    {
        print("presents delivered");
        GameObject childObject = transform.Find("TargetParticles").gameObject;
        childObject.SetActive(false);

        yield return new WaitForSeconds(2); // Wait a couple seconds before the typing starts
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        yield return null;
    }
}
