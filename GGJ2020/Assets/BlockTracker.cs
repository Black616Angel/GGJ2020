using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class BlockTracker : MonoBehaviour
{

    public int highscore;

    private List<Block> Blocks;
    private List<Vector2> usedFields;

    public void AddBlock(GameObject go, Fields fields)
    {
        Block block;
        block.block = go;
        fields.field1.x = (float)(Math.Round(fields.field1.x * 2f, MidpointRounding.AwayFromZero)) / 2f;
        fields.field1.y = (float)(Math.Round(fields.field1.y * 2f, MidpointRounding.AwayFromZero)) / 2f;

        fields.field2.x = (float)(Math.Round(fields.field2.x * 2f, MidpointRounding.AwayFromZero)) / 2f;
        fields.field2.y = (float)(Math.Round(fields.field2.y * 2f, MidpointRounding.AwayFromZero)) / 2f;

        fields.field3.x = (float)(Math.Round(fields.field3.x * 2f, MidpointRounding.AwayFromZero)) / 2f;
        fields.field3.y = (float)(Math.Round(fields.field3.y * 2f, MidpointRounding.AwayFromZero)) / 2f;

        fields.field4.x = (float)(Math.Round(fields.field4.x * 2f, MidpointRounding.AwayFromZero)) / 2f;
        fields.field4.y = (float)(Math.Round(fields.field4.y * 2f, MidpointRounding.AwayFromZero)) / 2f;

        block.fields = fields;
        Blocks.Add(block);

        if (fields.field1.x > highscore)
            highscore = (int)(fields.field1.x);
        if (fields.field2.x > highscore)
            highscore = (int)(fields.field2.x);
        if (fields.field3.x > highscore)
            highscore = (int)(fields.field3.x);
        if (fields.field4.x > highscore)
            highscore = (int)(fields.field4.x);
    }

    public void GetNextSpot(Fields placeableBlockFields, Vector2 playerPos, HorizontalMovement direction)
    {

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