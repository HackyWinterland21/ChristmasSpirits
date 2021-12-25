using UnityEngine;

public class GrabbableValue : MonoBehaviour
{
    [SerializeField] private int grabbableIndex;
    public int GrabbableIndex
    {
        get
        {
            return grabbableIndex;
        }
    }

}
