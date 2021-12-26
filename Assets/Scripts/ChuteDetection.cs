using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChuteDetection : MonoBehaviour
{
    [SerializeField] private int sortingIndex;
    [SerializeField] private GameObject objRespawnPoint;
    public static int numPackages;

    private void Start()
    {
        numPackages = 10;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "grabbable")
        {
            GrabbableValue objGrabbbleScript = collision.gameObject.GetComponent<GrabbableValue>();
            int objSortingVal = objGrabbbleScript.GrabbableIndex;

            HingeJoint2D hingeJoint2D = collision.gameObject.GetComponent<HingeJoint2D>();
            hingeJoint2D.enabled = false;
            hingeJoint2D.connectedBody = null;

            print(objSortingVal);
            print(sortingIndex);

            if (objSortingVal == sortingIndex)
            {
                // object is sorted correctly
                // remove it from the scene
                Destroy(collision.gameObject);
                numPackages--;
                if (numPackages == 0)
                {
                    StartCoroutine(FinishSorting());
                }
            } else
            {
                // object is sorted incorrectly
                // teleport it back to the main pile
                collision.gameObject.transform.position = new Vector3(objRespawnPoint.transform.position.x, objRespawnPoint.transform.position.y, objRespawnPoint.transform.position.z);
            }
        }
    }

    private IEnumerator FinishSorting()
    {
        yield return new WaitForSeconds(2); // Wait a couple seconds before the typing starts
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        yield return null;
    }
}
