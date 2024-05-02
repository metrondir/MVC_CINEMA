// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

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