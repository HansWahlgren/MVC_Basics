"use strict";

$(document).ready(function () {
    $.get("People/PersonPartialView", function (data, status) {
        //console.log("Data: " + data + "\nStatus: " + status);
        $("#peoplePartial").html(data);
    });
});

//with "this"
$(document).ready(function () {
    $("#CreateBtnPartial").click(function (create) {
        create.preventDefault(); var _this = $(this);
        $.get(_this.attr("href"), function (res) {
            //console.log("Data: " + data + "\nStatus: " + status);
            $('#' + _this.data("target")).html(res);
        });
    });
});

function confirmCreate(event) {
    console.log(event);
    event.preventDefault(); 
    var _this = event.target;

    $.post(_this.action + "/",
        {
            Name: _this[0].value,
            PhoneNumber: _this[1].value,
            City: _this[2].value
        },
        function (res) {
            $('#' + _this.dataset.target).html(res);
    });

    $("#createPartial").empty();

    //var personData = $('#ConfirmCreateForm').serialize();
    //console.log(personData);
}


function prepareRemove() {
    var allButtons = document.getElementsByClassName("RemoveBtnPartial");
    for (let button of allButtons) {
        button.addEventListener("click", remove);
    }
}

function remove() {
    $.get("People/RemovePerson/" + event.srcElement.id, function (data, status) {
        //console.log("Data: " + data + "\nStatus: " + status);
        $("#peoplePartial").html(data);
    });
}


function filterPeople(event) {


    //create.preventDefault(); var _this = $(this);
    //$.get(_this.attr("href"), function (res) {
    //    //console.log("Data: " + data + "\nStatus: " + status);
    //    $('#' + _this.data("target")).html(res);
    //});
});

