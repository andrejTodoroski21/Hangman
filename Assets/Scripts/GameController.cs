using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class GameController : MonoBehaviour
{

    public Text timeField;
    public Text WordToFindField;
    public GameObject[] HangMan;
    public GameObject WinText;
    public GameObject LoseText;
    public GameObject RestartButton; 
    private float time;
    private static readonly string[] vs = File.ReadAllLines(@"Assets/words.txt");

    //private string[] wordsLocal = {"RICH", "MINECRAFT", "VALORANT IS GOOD", "PHANTOM"};
    private string[] words = vs;
    private string chosenWord;
    private string hiddenWord;
    private int fails;
    private bool gameEnd = false;

    // Start is called before the first frame update
    void Start()
    {

        chosenWord = words[Random.Range(0, words.Length)];

        for (int i = 0; i < chosenWord.Length; i++)
        {
            char letter = chosenWord[i];
            Debug.Log(letter);

            if (char.IsWhiteSpace(letter))
            {
                hiddenWord += " ";
            }
            else
            {
                hiddenWord += "_";
            }

        }
        
        WordToFindField.text = hiddenWord;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameEnd == false)
        {
            time += Time.deltaTime;
            timeField.text = time.ToString();
        }
    }
    private void OnGUI()
    {
        Event e = Event.current;
        if(e.type == EventType.KeyDown && e.keyCode.ToString().Length == 1)
        {
            string pressed = e.keyCode.ToString();
            Debug.Log(pressed);
            if (chosenWord.Contains(pressed))
            {
                int i = chosenWord.IndexOf(pressed);
                while (i != -1)
                {
                    hiddenWord = hiddenWord.Substring(0, i) + pressed + hiddenWord.Substring(i + 1);
                    Debug.Log(hiddenWord);

                    chosenWord = chosenWord.Substring(0, i) + "_" + chosenWord.Substring(i + 1);
                    Debug.Log(hiddenWord);
                    i = chosenWord.IndexOf(pressed);
                }

                WordToFindField.text = hiddenWord;

            }
            else
            {
                HangMan[fails].SetActive(true);
                fails++;
            }
            if(fails == HangMan.Length)
            {
                LoseText.SetActive(true);
                RestartButton.SetActive(true);
                gameEnd = true;
            }
            if (!hiddenWord.Contains("_"))
            {
                WinText.SetActive(true);
                RestartButton.SetActive(true);
                gameEnd = true;
            }
        }
    }
}
