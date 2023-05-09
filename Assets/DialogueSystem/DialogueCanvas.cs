using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueCanvas : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DialogueSystemManager ds = DialogueSystemManager.Instance;
        ds.OnChosenChoice += Ds_OnChosenChoice;
        ds.OnContinueStory += Ds_OnContinueStory;
        ds.OnStoryChoices += Ds_OnStoryChoices;
        ds.OnStoryEnd += Ds_OnStoryEnd;
    }

    private void Ds_OnStoryEnd(object sender, System.EventArgs e)
    {
        Debug.Log("End");
    }

    private void Ds_OnStoryChoices(object sender, DialogueSystemManager.OnStoryChoicesArgs e)
    {
        Debug.Log(e.choices[0].text);
        Debug.Log(e.choices[1].text);
    }

    private void Ds_OnContinueStory(object sender, System.EventArgs e)
    {
        Debug.Log("NextLine");
    }

    private void Ds_OnChosenChoice(object sender, System.EventArgs e)
    {
        Debug.Log("Chosen");
    }
}
