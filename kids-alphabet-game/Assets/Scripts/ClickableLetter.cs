using System.Collections;
using System.Collections.Generic;
using TMPro;
using RTLTMPro;
using UnityEngine;
using UnityEngine.EventSystems;

enum LetterState
{
    New,
    Valid,
    Invalid
}

public class ClickableLetter : MonoBehaviour, IPointerClickHandler
{
    private RTLTextMeshPro tm;
    [SerializeField] private AlphabetGeneratorScriptableObject data = null;
    private AlphabetLetter currentLetter;
    private string currentVariation;
    private LetterState state = LetterState.New;
    [SerializeField] GameObject particlesObject = null;
    private ParticleSystem particles;

    private void OnEnable() {
        particles = particlesObject.GetComponent<ParticleSystem>();
        tm = GetComponent<RTLTextMeshPro>();
    }

    private void UpdateVisuals() {
        tm.text = currentVariation;
        if(state == LetterState.New) tm.color = Color.white;
        else if (state == LetterState.Valid) tm.color = Color.green;
    }

    public void SetLetter(AlphabetLetter letter){
        currentLetter = letter;
        state = LetterState.New;
        currentVariation = letter.variations[Random.Range(0, letter.variations.Length)];
        UpdateVisuals();
    }

    public bool CheckLetter(AlphabetLetter correctLetter) {
        if(state != LetterState.New) return false;
        bool result;
        if(correctLetter.name == currentLetter.name){
            state = LetterState.Valid;
            result = true;
            ShowParticles();
        } else {
            state = LetterState.Invalid;            
            result = false;
        }
        UpdateVisuals();
        return result;
    }

    private void ShowParticles() {
        particles.Play();
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        data.letterClickedEvent.Invoke(this);
    }
}
