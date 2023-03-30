mergeInto(LibraryManager.library, {

  Hello: function () {
    window.alert("Hello, world!");
    console.log("Hello, world!");
  },

  SaveExtern: function(date) {
    var dateInfo = UTF8ToString(date);
    var myobj = JSON.parse(dateInfo);
    player.setData(myobj);
  },

  LoadExtern: function() {
    player.getData().then(_date => {
      const myJSON = JSON.stringify(_date);
      myGameInstance.SendMessage('Progress','SetPlayerInfo',myJSON);
    })
  },
  
  ShowAdv : function(){
    ysdk.adv.showFullscreenAdv({
    callbacks: {
        onClose: function(wasShown) {
          // some action after close
        },
        onError: function(error) {
          // some action on error
        }
    }
    })
  },
});