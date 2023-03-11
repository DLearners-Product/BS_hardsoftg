mergeInto(LibraryManager.library, {

    SetBlendedData : function(jsonData){
        SetBlendedData_(Pointer_stringify(jsonData));
    },

    TeacherInst : function (htmlJson) {
        var json = Pointer_stringify(htmlJson)
	    localStorage.setItem('htmlJson', json);
    },

    Game : function(name){
        var myGameName = Pointer_stringify(name)
        localStorage.setItem('gameName', myGameName);
    },

    SyllabyfyText : function(textToSyllabify) {
        PerformSyllabifycation(UTF8ToString(textToSyllabify));
    }

});