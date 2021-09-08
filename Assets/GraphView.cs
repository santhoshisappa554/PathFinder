using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Graph))]
public class GraphView : MonoBehaviour
{
    public GameObject nodeViewPrefab;

    public Color baseColor = Color.white;
    public Color wallColor = Color.black;

    public void Init(Graph graph)
    {
        if (graph == null)
        {
            Debug.LogWarning("Graphview not available");
            return;
        }
        else
        {
            foreach (Node item in graph.nodes)
            {
               GameObject instance = Instantiate(nodeViewPrefab, Vector3.zero, Quaternion.identity);
                NodeView nodeView = instance.GetComponent<NodeView>();

                if (nodeView != null)
                {
                    nodeView.Init(item);
                    if (item.nodeType == NodeType.Blocked)
                    {
                        nodeView.ColorNode(wallColor);
                    }
                    else
                    {
                        nodeView.ColorNode(baseColor);
                    }
                }
            
            }
        }
    }
}
