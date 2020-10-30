using static System.String;
using System.Collections.Generic;
using System.Linq;
using RTLTMPro;
using TMPro;
using UnityEngine;



public class AlphabetGenerator : MonoBehaviour
{
    public AlphabetGeneratorScriptableObject data;
    [SerializeField] private int currentLetterIndex = -1;
    [SerializeField] private ClickableLetter clickableLetterPrefab = null;
    [SerializeField] private GameObject boardPanel = null;
    [SerializeField] private GameObject titleLetterText = null;
    [SerializeField] private int letterCount = 32;
    [SerializeField] private int correctLetterCount = 6;
    [SerializeField] private AudioClip correctLetterAudioClip = null;
    [SerializeField] private AudioClip completionAudioClip = null;
    private int remainingLetters;
    private ClickableLetter[] letterObjects;
    private AudioSource audioSource;

    private void Start() {
        UpdateGame();
        audioSource = GetComponent<AudioSource>();
        // data.remainingLettersChanged.Invoke(remainingLetters);
    }
    private void OnEnable() {
        data.letterClickedEvent.AddListener(OnLetterClicked);
        // GameObject.FindObjectOfType<StarsManager>().updateStars(remainingLetters);
    }
    private void OnDisable() {
        data.letterClickedEvent.RemoveListener(OnLetterClicked);
    }

    private void OnLetterClicked(ClickableLetter clickedLetter) {
        if(clickedLetter.CheckLetter(data.letters[currentLetterIndex])) {
            remainingLetters--;
            data.remainingLettersChanged.Invoke(remainingLetters);
            if(remainingLetters <= 0){
                audioSource.PlayOneShot(completionAudioClip);
                UpdateGame();
            } else {
                audioSource.PlayOneShot(correctLetterAudioClip);
            }
        } else {
            // Debug.Log("Clicked on wrong letter");
        }
    }

    private void UpdateGame() {
        InstanciateLetters();
        GenerateBoard();
        UpdateTitleLetter();
    }

    private void InstanciateLetters(){
        if(letterObjects == null){
            letterObjects = new ClickableLetter[letterCount];
            for (int i = 0; i < letterCount; i++)
            {
                GameObject letter = Instantiate(clickableLetterPrefab.gameObject, boardPanel.transform);
                letterObjects[i] = letter.GetComponent<ClickableLetter>();
            }
        }
    }

    private void UpdateTitleLetter() {
        string txt = System.String.Join("   ", data.letters[currentLetterIndex].variations);
        titleLetterText.GetComponent<RTLTextMeshPro>().text = txt;

    }

    private void GenerateBoard() {
        currentLetterIndex++;
        currentLetterIndex %= data.letters.Length;
        remainingLetters = correctLetterCount;
        data.remainingLettersChanged.Invoke(remainingLetters);
        AlphabetLetter currentLetter = data.letters[currentLetterIndex];
        List<AlphabetLetter> randomLetters = new List<AlphabetLetter>(letterCount);
        for(int i = 0 ; i < letterCount ; i++){
            if(i<correctLetterCount) randomLetters.Add(currentLetter);
            else randomLetters.Add(GetRandomLetter(currentLetter)); 
        }
        randomLetters = randomLetters.OrderBy(t=>Random.Range(0, 10000)).ToList<AlphabetLetter>();

        for(int i = 0 ; i < letterCount ; i++){
            letterObjects[i].SetLetter(randomLetters[i]);
        }
    }

    private AlphabetLetter GetRandomLetter(AlphabetLetter except){
        AlphabetLetter chosen;
        do{
            chosen = data.letters[Random.Range(0, data.letters.Length)];
        } while (chosen.name == except.name);
        return chosen;
    }
    
}
