using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ModalDialog : MonoBehaviour
{
    public Text dialogText;
    public Button option1Btn;
    public Button option2Btn;
    public Text option1Text;
    public Text option2Text;

    public void SetDialog(DialogObject dialog)
    {
        dialogText.text = dialog.dialogText;
        option1Text.text = dialog.option1;
        option2Text.text = dialog.option2;

        option1Btn.onClick.RemoveAllListeners();
        //confirm.onClick.AddListener(dialog.confirmEvent.Invoke);
    }
}

public class DialogObject
{
    public string dialogText;
    public string option1;
    public string option2;
    public UnityEvent confirmEvent;
}
