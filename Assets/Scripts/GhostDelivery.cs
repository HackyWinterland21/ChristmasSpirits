using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // move the character to the correct position ?

            // go to the end screen

            StartCoroutine(EndOfGame());
        }
    }

    private IEnumerator EndOfGame()
    {
        GameObject childObject = transform.Find("TargetParticles").gameObject;
        childObject.SetActive(false);

        yield return new WaitForSeconds(2); // Wait a couple seconds before the typing starts
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        yield return null;
    }
}
