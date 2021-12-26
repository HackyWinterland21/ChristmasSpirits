using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TargetTracker : MonoBehaviour
{
    [SerializeField] private int numTargets = 10;
    [SerializeField] private GameObject tree;
    private TreeGrow otherTree;

    private void Start()
    {
        otherTree = tree.GetComponent<TreeGrow>();
        //MoveTarget();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            numTargets--;
            otherTree.growTree();
            MoveTarget();
            if (numTargets == 0)
            {
                StartCoroutine(TreeMagic());
            }
            
        }
    }

    private void MoveTarget()
    {
        // generate a random location for new point
        Vector3 newLocation = new Vector3(Random.Range(-5.65f, -0.63f), Random.Range(3.02f, -3.7f), transform.position.z);

        // move target to that location
        transform.position = newLocation;
    }

    private IEnumerator TreeMagic()
    {
        GameObject childObject = transform.Find("TargetParticles").gameObject;
        childObject.SetActive(false);

        yield return new WaitForSeconds(2); // Wait a couple seconds before the typing starts
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        yield return null;
    }
}
