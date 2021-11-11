using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pnj : Interactable {

    [SerializeField]
    Dialogue dialog;

    public override void Interact() {
        base.Interact();
        if (Input.GetKey(KeyCode.K)) {
            this.TriggerDialog();
            this.game.dialogueManager.dialogWindow.SetActive(true);
        }
    }

    public override void QuitInteract() {
        base.QuitInteract();
    }
    public void TriggerDialog() {
        this.game.dialogueManager.StartDialog(this.dialog);
    }
}
