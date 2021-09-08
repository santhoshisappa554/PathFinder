using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public MapData mapData;
    public Graph graph;

    // Start is called before the first frame update
    void Start()
    {
        if(mapData!=null && graph != null)
        {
            int[,] mapInstance = mapData.MakeMyMap();
            graph.Init(mapInstance);
            GraphView graphView = graph.gameObject.GetComponent<GraphView>();
            if (graphView != null)
            {
                graphView.Init(graph);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
