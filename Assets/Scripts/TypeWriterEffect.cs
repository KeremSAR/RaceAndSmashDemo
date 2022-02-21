using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeWriterEffect : MonoBehaviour
{
    public float speed = 0.1f;
    public string fullText;
    private string currentText = "";
    private AudioSource _audioSource;
    
    void Start()
    {
        StartCoroutine(ShowText());
        _audioSource = GameObject.Find("Sound").GetComponent<AudioSource>();
    }

    IEnumerator ShowText()
    {
        for (int i = 0; i < fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            this.GetComponent<Text>().text = currentText;
            yield return new WaitForSeconds(speed);
            _audioSource.Play();
            if (i >= fullText.Length-1)
            {
                _audioSource.Stop();
            }
        }

        

    }
    
}
