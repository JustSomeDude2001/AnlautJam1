using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LogAllXML : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        foreach(string file in Directory.EnumerateFiles("Core", "Ability_*.xml", SearchOption.AllDirectories)) {
            Ability newResource = XMLOp<Ability>.Deserialize(file);
            //newResource.invokeEffect();
            //XMLOp<Ability>.Serialize(newResource, "test.xml");
        }
        foreach(string file in Directory.EnumerateFiles("Core", "Enemy_*.xml", SearchOption.AllDirectories)) {
            Enemy newResource = XMLOp<Enemy>.Deserialize(file);
            Debug.Log(newResource.position);
            //newResource.invokeEffect();
            //XMLOp<Ability>.Serialize(newResource, "test.xml");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
