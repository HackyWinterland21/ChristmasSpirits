using UnityEngine;

[CreateAssetMenu(menuName = "Dialog/DialogObject")]
public class DialogObject : ScriptableObject
{
    [SerializeField] [TextArea] private string[] dialog;
    public string[] Dialog => dialog; // a getter to access the private dialog string array

}
