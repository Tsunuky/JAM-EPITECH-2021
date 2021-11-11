using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : Jam {
    private Queue<string> sentences;
    public Text names;
    public Text discussion;
    
    public GameObject dialogWindow;
    float DSpeed = 1f;
    float DCooldown = 0f;

    void Start() {
        sentences = new Queue<string>();
    }

    void Update()
    {
        DCooldown -= Time.deltaTime;
        if (Input.GetKey(KeyCode.Return) && dialogWindow.active && DCooldown <= 0) {
                DisplayNextSentence();
                DCooldown = 1f / DSpeed;
        }
    }
    public void StartDialog(Dialogue dialog) {
        names.text = dialog.name;
        sentences.Clear();
        foreach (string sentence in dialog.sentence) {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }
    public void DisplayNextSentence() {
        if (sentences.Count == 0) {
            EndDialog();
            return;
        }
        string s = sentences.Dequeue();
        discussion.text = s;
    }

    void EndDialog() {
        dialogWindow.SetActive(false);
    }
}
