using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IntroCutScene : MonoBehaviour
{
    public string[] dialogue;
    public float timeBetweenLines;
    public bool skipCutscene;
    public TextMeshProUGUI dialogueTextMesh;
    private Rat rat;
    private 
    
    // Start is called before the first frame update
    void Start()
    {
        if (!skipCutscene)
        {
            rat = GetComponent<Rat>();
            rat.DisableMovement();
            StartCoroutine(Cutscene());
        }
    }

    private IEnumerator Cutscene()
    {
        foreach (var line in dialogue)
        {
            dialogueTextMesh.text = line;
            yield return new WaitForSeconds(timeBetweenLines);
        }
        
        dialogueTextMesh.text = "";
        dialogueTextMesh.gameObject.SetActive(false);
        rat.EnableMovement();
    }
}
