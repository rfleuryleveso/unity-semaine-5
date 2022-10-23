using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
    [SerializeField] private Discussion discussion;
    [SerializeField] private TMP_Text dialogDisplay;
    [SerializeField] private Button nextButton;
    [SerializeField] private Button previousButton;

    private int dialogIndex = 0;

    private void Start()
    {
        nextButton.onClick.AddListener(this.HandleNextButton);
        previousButton.onClick.AddListener(this.HandlePreviousButton);
        this.UpdateDialogDisplay(dialogIndex);
    }

    private void UpdateDialogDisplay(int index)
    {
        if (index >= 0 && index < discussion.dialogues.Count)
        {
            dialogDisplay.text = discussion.dialogues[index];
        }

        this.nextButton.enabled = index < discussion.dialogues.Count - 1;
        this.previousButton.enabled = index > 0;
    }

    private void HandleNextButton()
    {
        if (this.dialogIndex + 1 <= (discussion.dialogues.Count - 1))
        {
            this.dialogIndex++;
        }

        this.UpdateDialogDisplay(this.dialogIndex);
    }

    private void HandlePreviousButton()
    {
        if (this.dialogIndex - 1 >= 0)
        {
            this.dialogIndex--;
        }

        this.UpdateDialogDisplay(this.dialogIndex);
    }
}