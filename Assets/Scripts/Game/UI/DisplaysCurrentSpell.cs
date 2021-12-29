using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplaysCurrentSpell : MonoBehaviour
{
    public AbilityController abilityController;
    TextMeshProUGUI selfText;

    private void Start() {
        selfText = GetComponent<TextMeshProUGUI>();
    }
    // Update is called once per frame
    void Update()
    {
        selfText.text = abilityController.currentString;
    }
}
