mergeInto(LibraryManager.library, {

	
	TeacherInst: function (htmlJson) {
     var json = Pointer_stringify(htmlJson)
	localStorage.setItem('htmlJson', json);
  },

  Game: function(name){
  var myGameName = Pointer_stringify(name)
	localStorage.setItem('gameName', myGameName);
  },

  SendBlendedData: (slide_id, blended_activity_data) => {
    send_data()
  }

});