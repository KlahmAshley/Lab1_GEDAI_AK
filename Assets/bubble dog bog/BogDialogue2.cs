using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BogDialogue2 : MonoBehaviour
{

    public Text dialogText;
    public GameObject dialogPanel;
    private string[] dialogLines = { "Bubbly girl it's good that you, successfully made it to level 2 ", "Make sure you don't fall all the way down, because in this level there is no ground!", "Its a little tricky, but you got this girl! Now go off, get the bubbles; give it a whirl!"};
    private int currentLine = -1;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (dialogPanel.activeSelf)
                NextLine();
            else
                StartDialog();
        }
    }

    void StartDialog()
    {
        dialogPanel.SetActive(true);
        dialogText.text = dialogLines[currentLine];
    }

    void NextLine()
    {
        currentLine++;
        if (currentLine < dialogLines.Length)
            dialogText.text = dialogLines[currentLine];
        else
            dialogPanel.SetActive(false);
    }


}
