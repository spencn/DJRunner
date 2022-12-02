/*using System.Collections;
using UnityEngine;
using RhythmTool;

public class Importer : MonoBehaviour
{
    public AudioImporter importer;
    public AudioSource audioSource;
    public RhythmAnalyzer analyzer;
    public string filePath;
    void Awake()
    {
        //browser.FileSelected += OnFileSelected;
        filePath = globalControl.Instance.filePath;
        fileSelected(filePath);
    }

    public void fileSelected(string path)
    {
        Destroy(audioSource.clip);

        StartCoroutine(Import(path));
    }

    IEnumerator Import(string path)
    {
        importer.Import(path);

        while (!importer.isInitialized && !importer.isError)
            yield return null;

        if (importer.isError)
            Debug.LogError(importer.error);

        audioSource.clip = importer.audioClip;
        analyzer.Analyze(audioSource.clip);
        audioSource.Play();
    }
}*/
