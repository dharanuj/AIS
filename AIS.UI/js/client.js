var Client = function () {
    var _self = this;

    _self.clients = ko.observableArray([]);

    _self.getClientInfo = function () {
        var txtValue = $('#txtSearch').val();
        if (txtValue) {
            $('#errSearch').text('');
            var searchText = parseInt(txtValue) ? 'id' : 'lastName';
            var searchId, searchName;
            if (searchText == 'id') {
                searchId = parseInt(txtValue);
                searchName = 'null';
            }
            else {
                searchId = -1;
                searchName = txtValue;
            }
            $.ajax({
                type: 'GET',
                url: '/api/client/?id=' + searchId + '&lastName=' + searchName
            }).done(function (response) {
                _self.clients(response);
            }).fail(function () {
                alert('Something went wrong. Please refresh the page and try again.');
            });
        }
        else
            $('#errSearch').text('Please enter some search parameter');
    }

    _self.saveClientInfo = function () {
        if (_self.validateInfo()) {
            var client = _self.formClientObj();
            $.ajax({
                type: 'POST',
                url: '/api/client/',
                data: client
            }).done(function (response) {
                if (response != -1) {
                    _self.closePopup('addNewClient');
                    _self.clearData();
                }
                else
                    alert('Some error occurred. Please refresh the page and try again');
            }).fail(function () {
                alert('Some error occurred. Please refresh the page and try again.');
            });
        }
        else
            alert('Please fill all the fields');
    }

    _self.formClientObj = function () {
        var client = {};
        client['Status'] = $('#status option:selected').text();
        client['Course'] = $('#course option:selected').text();
        client['LName'] = $('#txtLastName').val();
        client['MName'] = $('#txtMiddleName').val();
        client['FName'] = $('#txtFirstName').val();
        client['City'] = $('#txtCity').val();
        client['Gender'] = $('input[name="rdbGender"]:checked').val();
        client['ImageUrl'] = $('#image').text();
        return client;
    }

    _self.clearData = function () {
        $('#txtLastName').val('');
        $('#txtFirstName').val('');
        $('#txtMiddleName').val('');
        $('#txtCity').val('');
    }

    _self.validateInfo = function () {
        return ($('#txtLastName').val() && $('#txtFirstName').val() && $('#txtCity').val());
    }

    _self.openPopup = function (selector) {
        $('#' + selector).removeClass('hide');
    }

    _self.preFillClientInfo = function (id ) {

    }

    _self.closePopup = function (selector) {
        $('#' + selector).addClass('hide');
    }

    _self.setSelectedClient = function (selector, id) {
        $('#clientInfo tr').removeClass('selected');
        $(selector).addClass('selected');
        _self.openPopup('addNewClient');
        _self.preFillClientInfo(id);
    }

    _self.signout = function () {
        $.cookie('username', '', { path: '/' });
        window.location.href = '/';
    }
}

$(document).ready(function () {
    if (!$.cookie('username'))
        window.location.href = '/';
    client = new Client();
    ko.applyBindings(client, document.getElementById('client'));
});