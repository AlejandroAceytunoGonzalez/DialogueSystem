using Ink.Runtime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueSystemManager : MonoBehaviour
{
    public static DialogueSystemManager Instance { get; private set; }

    public event EventHandler OnContinueStory;

    public event EventHandler<OnStoryChoicesArgs> OnStoryChoices;
    public class OnStoryChoicesArgs: EventArgs
    {
        public string choiceText;
        public List<Choice> choices;
    }

    public event EventHandler OnChosenChoice;
    public event EventHandler OnStoryEnd;

    public TextAsset inkFile;

    private Story story;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            story = new Story(inkFile.text);
        }
        else
            Destroy(this);
    }
    public void NextLine()
    {
        if (story.canContinue)
        {
            string text = story.Continue();
            text = text.Trim();
            if (story.currentChoices.Count > 0)
            {
                //Story has choices in next line
                List<Choice> choices = new List<Choice>();
                foreach (Choice choice in story.currentChoices)
                {
                    choices.Add(choice);
                }
                OnStoryChoices?.Invoke(this, new OnStoryChoicesArgs
                {
                    choiceText = text,
                    choices = choices
                });;
            }
            else
            {
                OnContinueStory?.Invoke(this, EventArgs.Empty);
            }
        }
        else
        {
            OnStoryEnd?.Invoke(this,EventArgs.Empty);
        }
    }
    public void ChooseOption(Choice choice)
    {
        if (story.currentChoices.Count > 0)
        {
            story.ChooseChoiceIndex(choice.index);
            OnChosenChoice?.Invoke(this, EventArgs.Empty);
        }
    }
    public bool CanContinue()
    {
        return story.canContinue;
    }
    public string GetCurrentText()
    {
        return story.currentText.Trim();
    }
    public void GoToStartOfKnot(string knotName)
    {
        Container containerToGo = story.KnotContainerWithName(knotName);
        story.ChoosePath(containerToGo.path);
        NextLine();
    }
}
