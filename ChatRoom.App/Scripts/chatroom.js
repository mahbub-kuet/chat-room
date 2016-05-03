
var chatroom = (function () {
    return {
        refreshChatBox: function () {
            $.get('/api/chat/GetMessages').then(function (data) {
                if (data && data.length > 0) {
                    chatroom.updateChatBox(data);
                }                
            });          
            
        },
        updateChatBox: function (messages) {
           
            $(".chatBox").html('');
            messages.forEach(function (element, index) {

               
                var msg = '<div class="media msg">' +
                            '<div class="media-body">' +
                                '<small class="pull-right time"><i class="fa fa-clock-o"></i>' + element.Time + '</small>' +
                                '<h5 class="media-heading" style="font-weight: bold; font-family: verdana; color:' + element.color + ' ">' + element.UserName + '</h5>' +
                                '<small class="col-lg-10">' + element.Text + '</small>' +
                            '</div>' +
                          '</div>'

                $(".chatBox").append(msg);
            });
                     

    }
    }
})();


$(document).ready(function () {

    if (!localStorage.getItem('user')) {
        var user = prompt("Please enter username");
        localStorage.setItem('user', user);       
        $.post("/api/chat/UserColor", { user: user});
    }

    //$(window).bind('beforeunload', function (e) {
    //    alert('fired');
    //    localStorage.removeItem('user');
    //});

    //$(window).unload(function (e) {
    //    debugger;
    //    console.log(e);
    //});

    $("#btnSave").click(function () {
        $.post("/api/chat/Save").then(function () {

        });
    });

    $(".messageBox").keydown(function (e) {
        if (e.keyCode == 13) {
            var message = {
                Username: localStorage.getItem('user'),
                text: $(".messageBox").val()
            };
            $.post("/api/chat/AddMessage", message);
            $(".messageBox").val('');
            chatroom.refreshChatBox();
            $(".chatBox").scrollTop($(".chatBox")[0].scrollHeight);
        }
    });

    setInterval('chatroom.refreshChatBox()', 1000);   
    $(".chatBox").scrollTop($(".chatBox")[0].scrollHeight);
    $(".heading").html(localStorage.getItem('user'));

});