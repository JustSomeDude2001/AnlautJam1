using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LightsUpwhenKeyPressed : MonoBehaviour
{
    TextMeshPro selfText;
    public KeyCode key;
    public Vector3 newScale;
    public Color newColor;

    Color defaultColor;

    private void Start() {
        selfText = GetComponent<TextMeshPro>();
        defaultColor = selfText.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(key)) {
            transform.localScale = newScale;
            selfText.color = newColor;
        } else {
            transform.localScale = new Vector3(1, 1, 1);
            selfText.color = defaultColor;
        }
    }
}
