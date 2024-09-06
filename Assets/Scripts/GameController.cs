using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public Text timeField;
    public Text WordToFindField;
    private float time;
    private string[] wordsLocal = {"RICH", "MINECRAFT", "VALORANT", "PHANTOM"};
    private string chosenWord;
    private string hiddenWord;

    // Start is called before the first frame update
    void Start()
    {
        chosenWord = wordsLocal[Random.Range(0,3)];
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        timeField.text= time.ToString();
    }
}
