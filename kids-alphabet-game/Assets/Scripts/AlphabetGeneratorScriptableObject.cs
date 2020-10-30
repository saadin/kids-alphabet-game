using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public struct AlphabetLetter 
{
    public string name { get; }
    public string[] variations { get; }

    public AlphabetLetter(string name, string[] variations){
        this.name = name;
        this.variations = variations;
    }

    public string GetRandomVariation(){
        return variations[Random.Range(0, variations.Length)];
    }
}

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/alphabetGeneratorScriptableObject", order = 1)]
public class AlphabetGeneratorScriptableObject : ScriptableObject
{
    public UnityEvent<ClickableLetter> letterClickedEvent = new UnityEvent<ClickableLetter>();
    public UnityEvent<int> remainingLettersChanged = new UnityEvent<int>();

    public AlphabetLetter[] letters = new AlphabetLetter[] {
        new AlphabetLetter("alef", new string[] {"ا", "آ"}),
        new AlphabetLetter("b", new string[] {"ب", "بـ"}),
        new AlphabetLetter("p", new string[] {"پ", "پـ",}),
        new AlphabetLetter("t", new string[] {"ت", "تـ"}),
        new AlphabetLetter("th", new string[] {"ث", "ثـ"}),
        new AlphabetLetter("j", new string[] {"ج", "جـ"}),
        new AlphabetLetter("ch", new string[] {"چ", "چـ"}),
        new AlphabetLetter("hh", new string[] {"ح", "حـ"}),
        new AlphabetLetter("kh", new string[] {"خ", "خـ"}),
        new AlphabetLetter("d", new string[] {"د"}),
        new AlphabetLetter("zal", new string[] {"ذ"}),
        new AlphabetLetter("r", new string[] {"ر"}),
        new AlphabetLetter("z", new string[] {"ز"}),
        new AlphabetLetter("s", new string[] {"س", "سـ"}),
        new AlphabetLetter("sh", new string[] {"ش", "شـ"}),
        new AlphabetLetter("sad", new string[] {"ص", "صـ"}),
        new AlphabetLetter("zad", new string[] {"ض", "ضـ"}),
        new AlphabetLetter("ta", new string[] {"ط", "طـ"}),
        new AlphabetLetter("za", new string[] {"ظ", "ظـ"}),
        new AlphabetLetter("ein", new string[] {"ع", "عـ"}),
        new AlphabetLetter("ghein", new string[] {"غ", "غـ"}),
        new AlphabetLetter("f", new string[] {"ف", "فـ"}),
        new AlphabetLetter("gh", new string[] {"ق", "قـ"}),
        new AlphabetLetter("k", new string[] {"ک", "کـ"}),
        new AlphabetLetter("g", new string[] {"گ", "گـ"}),
        new AlphabetLetter("l", new string[] {"ل", "لـ"}),
        new AlphabetLetter("m", new string[] {"م", "مـ"}),
        new AlphabetLetter("n", new string[] {"ن", "نـ"}),
        new AlphabetLetter("v", new string[] {"و"}),
        new AlphabetLetter("h", new string[] {"ه", "هـ", "ـهـ"}),
        new AlphabetLetter("y", new string[] {"ی", "یـ"}),
    };

    // public AlphabetLetter[] letters = new AlphabetLetter[] {
    //     new AlphabetLetter("alef", new string[] {"ا", "آ", "ـا"}),
    //     new AlphabetLetter("b", new string[] {"ب", "بـ", "ـبـ"}),
    //     new AlphabetLetter("p", new string[] {"پ", "پـ", "ـپـ"}),
    //     new AlphabetLetter("t", new string[] {"ت", "تـ", "ـتـ"}),
    //     new AlphabetLetter("th", new string[] {"ث", "ثـ", "ـثـ"}),
    //     new AlphabetLetter("j", new string[] {"ج", "جـ", "ـجـ"}),
    //     new AlphabetLetter("ch", new string[] {"چ", "چـ", "ـچـ"}),
    // };
    // public char[] alphabetChars = new char[]{
    //     (char)1575,
    //     (char)1576,
    //     (char)1662,
    //     (char)1578,
    //     (char)1579,
    //     (char)1580,
    //     (char)1670,
    //     (char)1581,
    //     (char)1582,
    //     (char)1583,
    //     (char)1584,
    //     (char)1585,
    //     (char)1586,
    //     (char)1587,
    //     (char)1588,
    //     (char)1589,
    //     (char)1590,
    //     (char)1591,
    //     (char)1592,
    //     (char)1593,
    //     (char)1594,
    //     (char)1601,
    //     (char)1602,
    //     (char)1705,
    //     (char)1711,
    //     (char)1604,
    //     (char)1605,
    //     (char)1606,
    //     (char)1608,
    //     (char)1607,
    //     (char)1740
    // };
}