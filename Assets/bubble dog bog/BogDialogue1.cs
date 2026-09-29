using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BogDialogue1 : MonoBehaviour
{
    public Text dialogText;
    public GameObject dialogPanel;
    private string[] dialogLines = { "My names Bog the Bubble Dog And this right heres my dialogue!", " I dont add much to this game, but im pretty fun so me and jucie are the same", 
        " Floaty McGee now must be on her way, pop the evil bubbles and save the day!",
       " Go on McGee! Youll see me again in levels 2 and 3!" }; 
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
