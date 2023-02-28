﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class CommonScript
{
    public int id;
    public string strVal;

    public CommonScript(int id, string strVal){
        this.id = id;
        this.strVal = strVal;
    }
}

[Serializable]
public class SlideDataContainer{
    public string slideName;
    public GameObject slideObject;
    public List<TextComponentData> textComponents;
}

[Serializable]
public class TextComponentData{
    public string componentID;
    public GameObject component;

    public TextComponentData(string componentID, GameObject component){
        this.componentID = componentID;
        this.component = component;
    }
}

[Serializable]
public class SlideData{
    public string slideName;
    public string slideTexts;
}

[Serializable]
public class TextComponent{
    public string key;
    public string value;
    public TextComponent(string id, string value){
        this.key = id;
        this.value = value;
    }
}