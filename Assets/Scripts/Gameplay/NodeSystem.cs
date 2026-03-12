using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
namespace Gameplay
{
    public class NodeSystem
    {
        public static Node GenerateNewNode(Node father,Node mother)
        {
            if(father == null || mother == null)
            {
                Debug.LogError("Father or Mother is null");
                return null;
            }
            GameObject newGameObject = new GameObject();
            newGameObject.name = "Node" + Guid.NewGuid().ToString();
            newGameObject.transform.position = Vector3.zero;
            SpriteRenderer spriteRenderer = newGameObject.AddComponent<SpriteRenderer>();
            newGameObject.AddComponent<CircleCollider2D>();
            Node newNode = newGameObject.AddComponent<Node>();

            newNode.bornOriginPoint = GteBornOriginPoint(father, mother);
            GraphicStyle[] newGraphicStyles = new GraphicStyle[3];
            for (int i = 0; i < 2; i++)
            {
                newGraphicStyles[i] = father.graphicStyles[i];
            }
            newGraphicStyles[2] = mother.graphicStyles[2];
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var item in newGraphicStyles)
            {
                if(item == GraphicStyle.None)
                {
                    continue;
                }
                stringBuilder.Append(item.ToString());
            }
            spriteRenderer.sprite = ResouresLoader.Instance.GetTexture(stringBuilder.ToString());
            newNode.audioClip = ResouresLoader.Instance.GetAudio(stringBuilder.ToString());
            for (int i = 0; i < 3; i++)
            {
                newNode.graphicStyles[i] = newGraphicStyles[i];
            }
            return newNode;
        }

        public static Node ClickNode(Vector2 screenPosition)
        {
            Ray ray = Camera.main.ScreenPointToRay(screenPosition);
            RaycastHit2D hit2D = Physics2D.Raycast(ray.origin,ray.direction);
            if (hit2D.collider != null)
            {
                Node node = hit2D.collider.GetComponent<Node>();
                return node;
            }
            Debug.Log("Clicked on empty space");
            return null;
        }

        public static Vector2 GteBornOriginPoint(Node father,Node mother)
        {   
            return (father.transform.position + mother.transform.position) / 2;
        }

        public static string GetNodeName(Node node)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var item in node.graphicStyles)
            {
                if(item == GraphicStyle.None)
                {
                    continue;
                }
                stringBuilder.Append(item.ToString());
            }
            return stringBuilder.ToString();
        }
    }
    
}
