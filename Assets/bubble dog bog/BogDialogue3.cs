using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BogDialogue3 : MonoBehaviour
{

    public Text dialogText;
    public GameObject dialogPanel;
    private string[] dialogLines = { "Bubble McGee its great to see that you successfully made it to level 3", "Now the obstacles are pretty hard, avoid the big bubbles or you'll get charred!!",
        "Good luck Mcgee, save the bubble world including me!!", "...YIPPIE!!"};
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
