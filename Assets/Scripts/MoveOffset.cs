using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOffset : MonoBehaviour
{
    private Renderer meshRenderer;
    private Material currentMaterial;
    private float offset;
    public float incrementoOffset;
    public float speed;
    public string sortingLayer;
    public int orderInLayer;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();

        meshRenderer.sortingLayerName = sortingLayer;
        meshRenderer.sortingOrder = orderInLayer;

        currentMaterial = meshRenderer.material;
    }

    private void FixedUpdate()
    {
        offset += incrementoOffset;

        currentMaterial.SetTextureOffset("_MainTex", new Vector2(offset * speed, 0));
    }
}
