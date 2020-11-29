using System.Collections.Generic;
using UnityEngine;

public class NodeStabilizer : MonoBehaviour
{
    public List<GameObject> nodeToSetActive;
    public List<GameObject> nodeToSetInActive;

    private void Awake()
    {
        nodeToSetActive.ForEach(gameObject =>{
            gameObject.SetActive(true);
        });

        nodeToSetActive.ForEach(gameObject =>{
            gameObject.SetActive(false);
        });

        //Destroy self since I need this gameobject on awake only
        Destroy(gameObject);
    }
}
