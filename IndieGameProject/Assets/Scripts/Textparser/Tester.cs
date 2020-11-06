using System;
using System.Collections;
using System.Collections.Generic;
using TextParser;
using UnityEngine;

public class Tester : MonoBehaviour
{
    public TextAsset storyFile;

    private StoryFileParser _storyParser;

    private void Start()
    {
        _storyParser = new StoryFileParser(storyFile);
    }

    private void Update()
    {
        if (!Input.GetKeyDown("space") || !_storyParser.MoveNext()) return;
        Debug.Log(_storyParser.Current);
    }
}
