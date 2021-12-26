using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LogAllXML : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        foreach(string file in Directory.EnumerateFiles("Core", "Resource_*.xml", SearchOption.AllDirectories)) {
            Resource newResource = XMLOp<Resource>.Deserialize(file);
            Debug.Log(newResource.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
