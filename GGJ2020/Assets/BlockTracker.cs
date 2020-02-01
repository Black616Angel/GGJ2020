using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class BlockTracker : MonoBehaviour
{
    private List<Block> Blocks;
    private List<Vector2> usedFields;

    public void AddBlock(GameObject go, Fields fields)
    {
        Block block;
        block.block = go;
        fields.field1.x = (float)(Math.Round(transform.position.x * 2f, MidpointRounding.AwayFromZero)) / 2f;
        fields.field1.y = (float)(Math.Round(transform.position.y * 2f, MidpointRounding.AwayFromZero)) / 2f;

        fields.field2.x = (float)(Math.Round(transform.position.x * 2f, MidpointRounding.AwayFromZero)) / 2f;
        fields.field2.y = (float)(Math.Round(transform.position.y * 2f, MidpointRounding.AwayFromZero)) / 2f;

        fields.field3.x = (float)(Math.Round(transform.position.x * 2f, MidpointRounding.AwayFromZero)) / 2f;
        fields.field3.y = (float)(Math.Round(transform.position.y * 2f, MidpointRounding.AwayFromZero)) / 2f;

        fields.field4.x = (float)(Math.Round(transform.position.x * 2f, MidpointRounding.AwayFromZero)) / 2f;
        fields.field4.y = (float)(Math.Round(transform.position.y * 2f, MidpointRounding.AwayFromZero)) / 2f;

        block.fields = fields;
        Blocks.Add(block);
    }
}


struct Block
{
    public GameObject block;
    public Fields fields;
}

public struct Fields
{
    public Vector2 field1;
    public Vector2 field2;
    public Vector2 field3;
    public Vector2 field4;
}