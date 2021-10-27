using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System;


public class TypeReader 
{
    private string path = "Assets/root/data/TypeData/types.xml";
    private int numberOfTypes;

    private string idType;
    private string name;
    private string description;
    private int strenghtMultiplicator;
    private int weaknessMultiplicator;

    public TypeReader()
    {
        var reader = XmlReader.Create(this.path);
        while (reader.ReadToFollowing("Type")) { this.numberOfTypes++; }
    }

    public Type[] InstantiateTypes()
    {
        int i;
        Type[] types = new Type[this.numberOfTypes];
        try
        {
            var reader = XmlReader.Create(path);

            for (i = 0; i <this.numberOfTypes; i++)
            {
                reader.ReadToFollowing("Type");
                reader.MoveToFirstAttribute();
                this.idType = reader.Value;

                reader.MoveToFirstAttribute();
                this.name = reader.Value;

                reader.MoveToFirstAttribute();
                this.description = reader.Value;

                reader.MoveToNextAttribute();
                int.TryParse(reader.Value, out this.strenghtMultiplicator);

                reader.MoveToNextAttribute();
                int.TryParse(reader.Value, out this.weaknessMultiplicator);

                types[i] = new Type(this.idType, this.name, this.description, this.strenghtMultiplicator, this.weaknessMultiplicator);
            }
            reader.Close();

        }
        catch
        {
            Debug.Log("Error reading xml file!");
        }
        return types;
    }
}
