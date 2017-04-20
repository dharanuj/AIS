<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Client.aspx.cs" Inherits="AIS.UI.Users.Client" %>

<!DOCTYPE html>

<html>
<head>
    <title></title>
    <script type="text/javascript" src="../Scripts/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../Scripts/jquery-cookie.js"></script>
    <script type="text/javascript" src="../Scripts/knockout-3.4.2.js"></script>
    <script type="text/javascript" src="../js/client.js"></script>
    <link rel="stylesheet" type="text/css" href="../css/client.css" />
</head>
<body>
    <div id="client">
        <div>
            <ul>
                <li>Client</li>
                <li>Course</li>
                <li>Tally Board</li>
                <li>Identification</li>
                <li>User</li>
                <li>Report</li>
            </ul>
        </div>
        <h2>Client Window</h2><br />
        <div class="hide">
            <table>
                <tr>
                    <td>ID Number:</td>
                    <td>Status:</td>
                </tr>
                <tr>
                    <td>Full Name:</td>
                    <td>Course:</td>
                </tr>
                <tr>
                    <td>City:</td>
                </tr>
                <tr>
                    <td>Gender:</td>
                </tr>
            </table>
            <img src="#" />
        </div>
        <div>
            <h2><label>ID Number or Last Name</label></h2>
            <br />
            <input type="text" id="txtSearch"/>
            <button onclick="client.getClientInfo();">Search</button> <label id="errSearch"></label>
        </div>
        <div>
            <table>
                <tr>
                    <td>Client ID</td>
                    <td>Full Name</td>
                    <td>Gender</td>
                    <td>Status</td>
                    <td>Course</td>
                </tr>
                <tbody id="clientInfo" data-bind="foreach: clients">
                    <tr data-bind="event: { click: function () { client.setSelectedClient(this, $data.Id); return true; } }">
                        <td data-bind="text: $data.Id"></td>
                        <td data-bind="text: ($data.FName + ' ' + $data.MName + (($data.MName != '') ? ' ' : '') + $data.LName)"></td>
                        <td data-bind="text: ($data.Gender == 'm' ? 'Male' : 'Female')"></td>
                        <td data-bind="text: $data.Status"></td>
                        <td data-bind="text: $data.Course"></td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div>
            <button onclick="client.openPopup('addNewClient');">New</button>
            <button onclick="client.openUpdatePopup('addNewClient')">Update</button>
            <button>Delete</button>
        </div>
        <div id="addNewClient" class="hide">
            <button onclick="client.closePopup('addNewClient');">Close</button>
            <table>
                <tr>
                    <td>Status : </td>
                    <td>
                        <select id="status">
                            <option value="1">Admin</option>
                            <option value="2">Student</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>Course : </td>
                    <td>
                        <select id="course">
                            <option value="1">PN</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>Last Name : </td>
                    <td><input type="text" id="txtLastName" /></td>
                </tr>
                <tr>
                    <td>First Name : </td>
                    <td><input type="text" id="txtFirstName" /></td>
                </tr>
                <tr>
                    <td>Middle Name : </td>
                    <td><input type="text" id="txtMiddleName" /></td>
                </tr>
                <tr>
                    <td>City : </td>
                    <td><input type="text" id="txtCity" /></td>
                </tr>
                <tr>
                    <td>Gender : </td>
                    <td>
                        <input type="radio" name="rdbGender" value="m" checked /> <label>Male</label>
                        <input type="radio" name="rdbGender" value="f" /> <label>Female</label>
                    </td>
                </tr>
            </table>
            <button>Upload Photo</button> <br />
            <label id="image">C:/</label>
            <button onclick="client.saveClientInfo();">Save</button>
        </div>
    </div>
    <button onclick="client.signout();">Sign Out</button>
</body>
</html>
