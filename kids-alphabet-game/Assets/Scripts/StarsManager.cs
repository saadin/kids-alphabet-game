using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StarsManager : MonoBehaviour
{
    public AlphabetGeneratorScriptableObject data;
    [SerializeField] private GameObject starPrefab = null;

    private void OnEnable() {
        data.remainingLettersChanged.AddListener(updateStars);
    }

    private void OnDisable() {
        data.remainingLettersChanged.RemoveListener(updateStars);
    }

    public void updateStars(int remainingLetters)
    {
        while(remainingLetters > transform.childCount){
            Instantiate(starPrefab, transform);
        }

        foreach (Transform child in transform)
        {
            if(remainingLetters > 0){
                remainingLetters--;
                child.gameObject.SetActive(true);
            } else {
                child.gameObject.SetActive(false);
            }
        }
    }
}
