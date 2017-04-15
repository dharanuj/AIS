var User = function () {
    var _self = this;

    _self.validateUser = function () {
        $.ajax({
            type: 'GET',
            url: '/api/users/?username=abcd&password=defg',
            success: function (response) {
                console.log(response);
            },
            error: function (response) {
                console.log(JSON.parse(response.responseText));
            }
        });
        //}).done(function (response) {
        //    if (response)
        //        window.location.href = '#';
        //    else
        //        $('#errMsg').val('Invalid username or password');
        //});
    }

    _self.createUser = function () {
        // var userObj = '{"userName":' + $('#txtNewUserName').val() + ',"password":' + $('#txtNewPassword').val() + ',"status":' + $('#drpStatus option:selected').val() + '}'
        var userObj = { 'userName': $('#txtNewUserName').val(), 'password': $('#txtNewPassword').val(), 'status': $('#drpStatus option:selected').val() };
        $.ajax({
            type: 'POST',
            url: '/api/users/',
            data: JSON.stringify(userObj)
        }).done(function (response) {
            if (response)
                window.location.href = '#';
            else
                $('#newErrMsg').val('User already exists');
        });
    }

    _self.openPopup = function () {
        $('#userPopup').removeClass('hide');
    }
}

$(document).ready(function () {
    user = new User();
});