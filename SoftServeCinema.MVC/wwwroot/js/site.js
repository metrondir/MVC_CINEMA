// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
//$(document).ready(() => {
//    $('.form-control').select2();
//});
document.getElementById('alert').addEventListener('click', e => {
    e.target.remove();
});

//document.getElementById('login-button').addEventListener('click', e => {
//    const body = {};
//    body.email =
//    fetch('https://5304-178-255-168-80.ngrok-free.app', {
//        method: "POST",
//        headers: {
//            'Content-Type': 'application/json',
//        },

//    })
//})
window.addEventListener('load', function () {
    document.body.classList.add('loaded');
});

//window.onload = (event) => {
//    initMultiselect();
//};

//function initMultiselect() {
//    checkboxStatusChange();

//    document.addEventListener("click", function (evt) {
//        var flyoutElement = document.getElementById('myMultiselect'),
//            targetElement = evt.target; // clicked element

//        do {
//            if (targetElement == flyoutElement) {
//                // This is a click inside. Do nothing, just return.
//                //console.log('click inside');
//                return;
//            }

//            // Go up the DOM
//            targetElement = targetElement.parentNode;
//        } while (targetElement);

//        // This is a click outside.
//        toggleCheckboxArea(true);
//        //console.log('click outside');
//    });
//}

//function checkboxStatusChange() {
//    var multiselect = document.getElementById("mySelectLabel");
//    var multiselectOption = multiselect.getElementsByTagName('option')[0];

//    var values = [];
//    var checkboxes = document.getElementById("mySelectOptions");
//    var checkedCheckboxes = checkboxes.querySelectorAll('input[type=checkbox]:checked');

//    for (const item of checkedCheckboxes) {
//        var checkboxValue = item.getAttribute('value');
//        values.push(checkboxValue);
//    }

//    var dropdownValue = "Nothing is selected";
//    if (values.length > 0) {
//        dropdownValue = values.join(', ');
//    }

//    multiselectOption.innerText = dropdownValue;
//}

//function toggleCheckboxArea(onlyHide = false) {
//    var checkboxes = document.getElementById("mySelectOptions");
//    var displayValue = checkboxes.style.display;

//    if (displayValue != "block") {
//        if (onlyHide == false) {
//            checkboxes.style.display = "block";
//        }
//    } else {
//        checkboxes.style.display = "none";
//    }
//}