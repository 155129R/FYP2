using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class DialogueManager : MonoBehaviour
{
    Queue<string> dialogues;
    public GameObject dialogueBox;
    private int index = 0;

    private void Start()
    {
        index = 0;
        dialogues = new Queue<string>();
    }

    public void AdvanceText()
    {
        if (dialogues.Count - 1 >= 0)
            dialogueBox.GetComponentInChildren<UnityEngine.UI.Text>().text = dialogues.Dequeue();
        else
        {
            index = 0;
            dialogueBox.SetActive(false);
        }
    }

    public void SetText(List<string> dialogueList)
    {
        foreach(string dialogue in dialogueList)
        {
            dialogues.Enqueue(dialogue);
        }
    }

}
