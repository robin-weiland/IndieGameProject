using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;


[RequireComponent(typeof(Text))]
public class Textwriter : MonoBehaviour
{
    private Text _label;
    private string _finalText;

    [SerializeField]
    [Range(0, 1.0f)]
    public float delay;

    [Header("Random")]
    [SerializeField]
    [Range(0, 0.5f)]
    public float randomAmount;

    private List<string> word = new List<string>
    {
        "T",
        "Th",
        "Thi",
        "This",
        "This ",
        "This i",
        "This is",
        "This is ",
        "This is a",
        "This is a ",
        "This is a <color=green>T</color>",
        "This is a <color=green>Te</color>",
        "This is a <color=green>Tes</color>",
        "This is a <color=green>Test</color>",
        "This is a <color=green>Test!</color>"
    };
    
    
    private void Start()
    {
        _label = GetComponent<Text>();
        _finalText = _label.text;
        _label.text = "";
        StartCoroutine(Write());
    }

    private IEnumerator Write()
    {
        foreach (var c in word)
        {
            _label.text = c;
            yield return new WaitForSeconds(delay + Random.Range(0, randomAmount));
        }
    }
}
