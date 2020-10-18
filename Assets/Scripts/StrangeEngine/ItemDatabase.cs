﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public static List<Item> itemDatabase = new List<Item>()
    {
        new Item
            (
            0,
            "Example Item",
            "this is an example item being added to the database",
            10,
            new Dictionary<string, int>
            {
                {"Sword", 100}
            }
            ),
        new Item
            (
            1,
            "Sword",
            "This is a sword",
            100,
            new Dictionary<string, int>
            {
            }
            ),
        new Item
            (
            2,
            "Apple",
            "i'm hungry",
            10,
            new Dictionary<string, int>
            {
                {"hunger", 4 }
            },
            true
            )
    };

    public static Item SearchDatabaseByID(int ID)
    {
        for(int i = 0; i < itemDatabase.Count; i++)
        {
            if(ID == itemDatabase[i].ID)
            {
                return itemDatabase[i];
            }
        }
        return null;
    }

    public static Item SearchDatabaseByName(string Name)
    {
        for(int i = 0; i< itemDatabase.Count; i++)
        {
            if(Name == itemDatabase[i].itemName)
            {
                return itemDatabase[i];
            }
        }
        Debug.LogError("Tried searching item database for '" +Name+"': Item not found");
        return null;
    }
}
