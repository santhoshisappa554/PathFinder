using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    public Node[,] nodes;
    public List<Node> walls = new List<Node>();

    int[,] m_mapData;
    int m_width;
    int m_height;

    public static readonly Vector2[] allDirections =
    {
        new Vector2(0,1),
        new Vector2(1,1),
        new Vector2(1,0),
        new Vector2(1,-1),
        new Vector2(0,-1),
        new Vector2(-1,-1),
        new Vector2(-1,0),
        new Vector2(-1,0),
        new Vector2(-1,1)
    };

    public bool isWithInBounds(int x,int y)
    {
        return (x >= 0 && x < m_width && y >= 0 && y < m_height);
    }
    List<Node> GetNeighbours(int x, int y, Node[,] nodeArray, Vector2[] directions)
    {
        List<Node> neighboursNodes = new List<Node>();
        foreach  (Vector2 dir in directions)
        {
            int newX = x + (int)dir.x;
            int newY = y + (int)dir.y;

            if(isWithInBounds(newX,newY)&&nodeArray[newX,newY]!=null&& nodeArray[newX, newY].nodeType != NodeType.Blocked)
            {
                neighboursNodes.Add(nodeArray[newX, newY]);
            }
        }
        return neighboursNodes;
    }
    List<Node> GetNeighbours(int x,int y)
    {
        return GetNeighbours(x, y, nodes, allDirections);
    }


    public void Init(int[,] mapData)
    {
        m_mapData = mapData;
        m_width = mapData.GetLength(0);
        m_height = mapData.GetLength(1);

        nodes = new Node[m_width, m_height];

        for (int i = 0; i < m_width; i++)
        {
            for (int j = 0; j < m_height; j++)
            {
                NodeType type = (NodeType)mapData[i, j];
                Node newNode = new Node(i, j, type);
                nodes[i, j] = newNode;
                newNode.position = new Vector3(i, 0, j);
                if (type == NodeType.Blocked)
                {
                    walls.Add(newNode);
                }

            }

        }

        for (int y = 0; y < m_height; y++)
        {
            for (int x = 0; x < m_width; x++)
            {
                if (nodes[x, y].nodeType != NodeType.Blocked)
                {
                    nodes[x, y].neighbors = GetNeighbours(x, y);
                }
            }
        }
    }

}
