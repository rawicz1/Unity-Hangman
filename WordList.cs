using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class WordList : MonoBehaviour
{
    string wordsFilePath;
    List<string> words;
    // Start is called before the first frame update
    void Start()
    {
        wordsFilePath = System.IO.Path.Combine(Application.streamingAssetsPath,"wordlist.txt");
        words = File.ReadAllLines(wordsFilePath).ToList();        
    }

    public string GetRandomWord()
    {
        return words[Random.Range(0, words.Count)].ToUpper();
    }

}
