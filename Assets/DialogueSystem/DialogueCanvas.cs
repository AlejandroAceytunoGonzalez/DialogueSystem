using Ink.UnityIntegration;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueCanvas : MonoBehaviour
{
    public static DialogueCanvas Instance { get; private set; }

    private DialogueInkManager dialogueInk;
    private DialogueSystemDisplay textDisplay;
    private DialogueSystemDisplay optionsDisplay;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else Destroy(this);
    }
    void Start()
    {
        dialogueInk = DialogueInkManager.Instance;
        dialogueInk.OnChosenChoice += Ds_OnChosenChoice;
        dialogueInk.OnContinueStory += Ds_OnContinueStory;
        dialogueInk.OnStoryChoices += Ds_OnStoryChoices;
        dialogueInk.OnStoryEnd += Ds_OnStoryEnd;
    }
    public void StartDialogue(string knotName, DialogueSystemDisplay textDisplay, DialogueSystemDisplay optionsDisplay = null)
    {
        this.textDisplay = Instantiate(textDisplay,transform);
        this.optionsDisplay = Instantiate(optionsDisplay,transform);
        DialogueInkManager.Instance.GoToStartOfKnot(knotName);
    }
    private void Ds_OnStoryEnd(object sender, System.EventArgs e)
    {
        Destroy(textDisplay.gameObject);
        Destroy(optionsDisplay.gameObject);
    }

    private void Ds_OnStoryChoices(object sender, DialogueInkManager.OnStoryChoicesArgs e)
    {
        textDisplay.gameObject.SetActive(false);
        optionsDisplay.gameObject.SetActive(true);

        optionsDisplay.setText(dialogueInk.GetCurrentText());
        optionsDisplay.CreateOptions(e.choices);
    }

    private void Ds_OnContinueStory(object sender, System.EventArgs e)
    {
        textDisplay.setText(dialogueInk.GetCurrentText());
    }

    private void Ds_OnChosenChoice(object sender, System.EventArgs e)
    {
        optionsDisplay.gameObject.SetActive(false);
    }
}
