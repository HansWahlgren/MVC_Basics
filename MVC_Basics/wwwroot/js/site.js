"use strict";

$(document).ready(function () {
    $.get("People/PersonPartialView", function (data, status) {
        //console.log("Data: " + data + "\nStatus: " + status);
        $("#peoplePartial").html(data);
    });
});

//Without "this"
//$(document).ready(function () {
//    $("#CreateBtnPartial").click(function () {
//        $.get("People/CreatePerson", function (data, status) {
//            //console.log("Data: " + data + "\nStatus: " + status);
//            $("#createPartial").html(data);
//        });
//    });
//});

//with "this"
$(document).ready(function () {
    $("#CreateBtnPartial").click(function (update) {
        update.preventDefault(); var _this = $(this);
        $.get(_this.attr("href"), function (res) {
            //console.log("Data: " + data + "\nStatus: " + status);
            $('#' + _this.data("target")).html(res);
        });
    });
});

function prepareCreate() {
    //var CreateButton = document.getElementById("ConfirmCreateBtn");
    //CreateButton.addEventListener("click", confirmCreate)

    var CreateForm = document.getElementById("ConfirmCreateForm");
    console.log(CreateForm);
    CreateForm.addEventListener("submit", confirmCreate)
}


function confirmCreate() {
    console.log("TESTETST");
    var _this = $(this);
    $.get("People/CreatePerson/" + event.srcElement.id, function (data, status) {
        //console.log("Data: " + data + "\nStatus: " + status);
        $("#peoplePartial").html(data);
    });
}


function prepareRemove() {
    var allButtons = document.getElementsByClassName("RemoveBtnPartial");
    for (let button of allButtons) {
        //console.log(button.id);
        button.addEventListener("click", remove);
    }
}

function remove() {
    $.get("People/RemovePerson/" + event.srcElement.id, function (data, status) {
        //console.log("Data: " + data + "\nStatus: " + status);
        $("#peoplePartial").html(data);
    });
}


