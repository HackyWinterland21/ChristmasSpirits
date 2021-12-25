using System.Collections;
using UnityEngine;
using TMPro;

public class DialogUI : MonoBehaviour
{
    [SerializeField] private GameObject dialogBox;
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private DialogObject testDialog;

    private TypewriterEffect typewriterEffect;

    private void Start()
    {
        //textLabel.text = "Hello!\nThis is the second line.";
        //GetComponent<TypewriterEffect>().Run("French Fries are super awesome", textLabel);

        typewriterEffect = GetComponent<TypewriterEffect>();
        CloseDialogBox();

        ShowDialog(testDialog);

    }

    public void ShowDialog(DialogObject dialogObject)
    {
        dialogBox.SetActive(true);
        StartCoroutine(StepThroughDialog(dialogObject));
    }

    private IEnumerator StepThroughDialog(DialogObject dialogObject)
    {
        yield return new WaitForSeconds(2); // Wait a couple seconds before the typing starts

        foreach (string dialog in dialogObject.Dialog)
        {
            yield return typewriterEffect.Run(dialog, textLabel);
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        }

        CloseDialogBox();
    }

    private void CloseDialogBox()
    {
        dialogBox.SetActive(false);
        textLabel.text = string.Empty;
    }
}
