using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization; 
using System;
using System.IO;
using System.Xml;
using UnityEditor;
 
public class Serializator 
{	    
    static public void AddNewXml(BoardSerialize state,  IStrategyModificatedLevelEditor strategy , int NumberLevel)
	{
        FileStream fs =  StrategyModificatedLevelEditor.CreateLevel(strategy, NumberLevel );

        Type[] extraTypes = {typeof(SettingBoard.TypeLevel) , typeof(SettingBoard.TypeCellBoard)};
		 
		XmlSerializer serializer = new XmlSerializer(typeof(BoardSerialize) , extraTypes);                                                                                                   
    
        serializer.Serialize(fs, state); 
       
        fs.Dispose();

        fs.Close();  
 	} 

    static public void SaveXml(BoardSerialize state,  IStrategyModificatedLevelEditor strategy , int NumberLevel)
    {
        FileStream fs =  StrategyModificatedLevelEditor.SaveLevel(strategy, NumberLevel);

        Type[] extraTypes = {typeof(SettingBoard.TypeLevel) , typeof(SettingBoard.TypeCellBoard)};

        XmlSerializer serializer = new XmlSerializer(typeof(BoardSerialize) , extraTypes);                                                                                                   

        serializer.Serialize(fs, state); 

        fs.Dispose();
        fs.Close();   
    }
	
    static public BoardSerialize DeXml(IStrategyModificatedLevelEditor strategy , int NumberLevel)
	{		
        TextAsset textAsset = strategy.LoadLevel(NumberLevel);

        XmlDocument doc = new XmlDocument(); 

        doc.LoadXml(textAsset.text);

        Type[] extraTypes= { typeof(SettingBoard.TypeLevel) , typeof(SettingBoard.TypeCellBoard)};
        XmlSerializer serializer = new XmlSerializer(typeof(BoardSerialize), extraTypes);  

        //Указываем наш класс с данными которыеS нужно десериализовать, в нашем случае это ItemSetSerialized.
        XmlReader reader = new XmlNodeReader(doc.ChildNodes[1]);

        //Здесь рпоходит сама десериализация, в результате мы получаем новый экземпляр класса ItemSetSerialized, в который загрузятся все данные.
        BoardSerialize state = (BoardSerialize)serializer.Deserialize(reader);    

 
        return state;
	} 

    public static XmlDocument LoadXMLDocument(int numberLevel )
    {
        TextAsset textAsset = (TextAsset) Resources.Load("Prefabs/" + "Level_" +  (numberLevel + 1).ToString());
       
        XmlDocument doc = new XmlDocument();     
       
        doc.LoadXml(textAsset.text);

        Type[] extraTypes= { typeof(SettingBoard.TypeLevel) , typeof(SettingBoard.TypeCellBoard)};
        XmlSerializer serializer = new XmlSerializer(typeof(BoardSerialize), extraTypes);  
  
        //Указываем наш класс с данными которыеS нужно десериализовать, в нашем случае это ItemSetSerialized.
        XmlReader reader = new XmlNodeReader(doc.ChildNodes[1]);

        //Здесь рпоходит сама десериализация, в результате мы получаем новый экземпляр класса ItemSetSerialized, в который загрузятся все данные.
        BoardSerialize state = (BoardSerialize)serializer.Deserialize(reader);       
 
        return doc;
    }
 }   
