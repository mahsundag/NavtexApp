// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function uploadFile() {
    var formData = new FormData(document.getElementById('uploadForm'));

    fetch('/Home/Upload', {
        method: 'POST',
        body: formData
    })
        .then(response => response.text())
        .then(data => {
            document.getElementById('navtexMessage').innerHTML = data;
        });
}
