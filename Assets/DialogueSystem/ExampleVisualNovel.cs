using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleVisualNovel : MonoBehaviour
{
    /**
    [SerializeField] private TextAsset inkJsonAsset;
    [SerializeField] private Story story;
    [SerializeField] private TextMeshProUGUI textField;
    [SerializeField] private VerticalLayoutGroup choiceButtonContainer;
    [SerializeField] private Button choiceButtonPrefab;
    [SerializeField] private Button choiceButtonPrefabEnlightened;
    [SerializeField] private Button ContinueButton;
    [SerializeField] private TextMeshProUGUI ContinueButtonText;
    [SerializeField] private Color normalTextColor;
    [SerializeField] private Color thoughtTextColor;
    [SerializeField] private Color narratedTextColor;
    [SerializeField] private Color scaryTextColor;
    [SerializeField] private BackgroundManager backgroundManager;
    [SerializeField] private MusicController musicController;
    [SerializeField] private BoxController hud;
    [SerializeField] private CharacterManager characterController;
    [SerializeField] private float delay = 0.02f;
    [SerializeField] private float delayAuto = 10f;
    private AudioSource audioText;
    private bool canContinueButton = true;
    private string text;
    private int textIndex;
    private bool autoMode = false;
    private void Start()
    {
        audioText = GetComponent<AudioSource>();
        StartStory();
        DisplayNextLine();
    }
    private void StartStory()
    {
        story = new Story(inkJsonAsset.text);

        story.BindExternalFunction("ShowCharacter", (string name, string position, string mood)
        => characterController.ShowCharacter(name, position, mood));
        story.BindExternalFunction("HideCharacter", (string position, bool instant)
        => characterController.HideCharacter(position, instant));
        story.BindExternalFunction("Yeet", (bool state)
        => characterController.Yeet(state));
        story.BindExternalFunction("HugR", (bool state)
        => characterController.HugR(state));
        story.BindExternalFunction("HugL", (bool state)
        => characterController.HugL(state));

        story.BindExternalFunction("ShowBackground", (string backgroundName)
        => backgroundManager.ChangeBackground(backgroundName));
        story.BindExternalFunction("ColorBackground", (float r, float g, float b)
        => backgroundManager.ColorBackground(r, g, b));
        story.BindExternalFunction("Falling", (bool state, float speed)
        => backgroundManager.Fall(state, speed));
        story.BindExternalFunction("Moving", (bool state, float speed)
        => backgroundManager.Move(state, speed));

        story.BindExternalFunction("Dreaming", (bool state)
        => hud.Dreaming(state));

        story.BindExternalFunction("ChangeMusic", (string musicName, float volume)
        => musicController.ChangeMusic(musicName, volume));

        story.BindExternalFunction("AutoMode", (bool mode)
        => AutoMode(mode));
        story.BindExternalFunction("End", ()
        => ContinueButtonText.text = "The End");
    }
    public void DisplayNextLine()
    {
        if (!autoMode)
        {
            if (!canContinueButton)
            {
                StopAllCoroutines();
                textField.text = text;
                canContinueButton = true;
            }
            else if (story.canContinue && canContinueButton)
            {
                text = story.Continue(); // gets next line
                text = text?.Trim(); // removes white space from text
                ApplyStyling();
                canContinueButton = false;
                StartCoroutine(WriteText()); // displays new text
            }
            else if (story.currentChoices.Count > 0)
            {
                DisplayChoices();
            }
        }
    }
    private void DisplayChoices()
    {
        // checks if choices are already being displaye
        if (choiceButtonContainer.GetComponentsInChildren<Button>().Length > 0) return;

        for (int i = 0; i < story.currentChoices.Count; i++) // iterates through all choices
        {

            var choice = story.currentChoices[i];
            var button = CreateChoiceButton(choice.text); // creates a choice button

            button.onClick.AddListener(() => OnClickChoiceButton(choice));
        }
    }
    Button CreateChoiceButton(string text)
    {
        if (hud.dreaming)
        {
            // creates the button from a prefab
            var choiceButton = Instantiate(choiceButtonPrefabEnlightened);
            choiceButton.transform.SetParent(choiceButtonContainer.transform, false);

            // sets text on the button
            var buttonText = choiceButton.GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = text;

            return choiceButton;
        }
        else
        {
            // creates the button from a prefab
            var choiceButton = Instantiate(choiceButtonPrefab);
            choiceButton.transform.SetParent(choiceButtonContainer.transform, false);

            // sets text on the button
            var buttonText = choiceButton.GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = text;

            return choiceButton;
        }
    }
    void OnClickChoiceButton(Choice choice)
    {
        story.ChooseChoiceIndex(choice.index); // tells ink which choice was selected
        RefreshChoiceView(); // removes choices from the screen
        story.Continue();
        DisplayNextLine();
    }
    void RefreshChoiceView()
    {
        if (choiceButtonContainer != null)
        {
            foreach (var button in choiceButtonContainer.GetComponentsInChildren<Button>())
            {
                Destroy(button.gameObject);
            }
        }
    }
    private void ApplyStyling()
    {
        textField.color = normalTextColor;
        textField.fontStyle = FontStyles.Normal;
        if (story.currentTags.Contains("Thought"))
        {
            textField.color = thoughtTextColor;
            textField.fontStyle = FontStyles.Italic;
        }
        if (story.currentTags.Contains("Narrated"))
        {
            textField.color = narratedTextColor;
        }
        if (story.currentTags.Contains("Scary"))
        {
            textField.color = scaryTextColor;
        }
    }
    private void AutoMode(bool mode)
    {
        autoMode = mode;
        ContinueButton.gameObject.SetActive(!autoMode);
    }
    IEnumerator WriteText()
    {
        textField.text = "";
        textIndex = 0;
        if (autoMode) StartCoroutine(AutoText());
        while (textIndex <= text.Length - 1)
        {
            var timer = delay;
            textField.text += text[textIndex];
            if (!audioText.isPlaying) audioText.Play();
            textIndex++;
            while (timer >= 0)
            {
                timer -= Time.deltaTime;
                yield return null;
            }
        }
        canContinueButton = true;
    }
    IEnumerator AutoText()
    {
        var timer = delayAuto + text.Length * delay;
        while (timer >= 0)
        {
            timer -= Time.deltaTime;
            yield return null;
        }
        if (story.canContinue)
        {
            text = story.Continue(); // gets next line
            text = text?.Trim(); // removes white space from text
            ApplyStyling();
            canContinueButton = false;
            StartCoroutine(WriteText()); // displays new text
        }
    }
    private void Update()
    {
        if (Input.GetButtonDown("Next")) DisplayNextLine();
    }
    **/
}