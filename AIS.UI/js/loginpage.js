var User = function () {
    var _self = this;

    _self.validateUser = function () {
        if (_self.checkUserDetails($('#txtUserName').val(), $('#txtPassword').val())) {
            $.ajax({
                type: 'GET',
                url: '/api/users/?username=' + $('#txtUserName').val() + '&password=' + $('#txtPassword').val()
            }).done(function (response) {
                if (response) {
                    $.cookie('username', $('#txtUserName').val(), { path: '/' });
                    window.location.href = '/Users/Client.aspx';
                }
                else
                    $('#errMsg').text('Invalid username or password');
            }).fail(function () {
                alert("Something went wrong. Please refresh the page and try again");
            });
        }
        else
            $('#errMsg').text('Please enter username and password');
    }

    _self.createUser = function () {
        if (_self.checkUserDetails($('#txtNewUserName').val(), $('#txtNewPassword'))) {
            var userObj = { 'Username': $('#txtNewUserName').val(), 'Password': $('#txtNewPassword').val(), 'Status': parseInt($('#drpStatus option:selected').attr('id')) };
            $.ajax({
                type: 'POST',
                url: '/api/users/',
                data: userObj
            }).done(function (response) {
                if (response) {
                    $.cookie('username', $('#txtNewUserName'.val(), { path: '/' }));
                    window.location.href = '/Users/Client.aspx';
                }
                else
                    $('#newErrMsg').text('User already exists');
            }).fail(function () {
                alert('Something went wrong. Please refresh the page and try again.');
            });
        }
        else
            $('#newErrMsg').text('Please enter username and password');
    }

    _self.openPopup = function () {
        $('#userPopup').removeClass('hide');
    }

    _self.checkUserDetails = function (username, password) {
        if (username && password)
            return true;
        else
            return false;
    }
}

$(document).ready(function () {
    if ($.cookie('username'))
        window.location.href = '/Users/Client.aspx';
    user = new User();
});