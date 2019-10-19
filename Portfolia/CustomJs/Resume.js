
function SendPassword() {
    var password = $('#pwd').val();
    $.post("/Home/DownloadList", { password: password }).done(function (data) {
        if (data === null) {
            alert("Nutze bitte eine gültige Kennung");
        } else {
            $('#registration').hide();
            $('#repl').replaceWith(data);
        }
    });
}

function DownloadFile(id) {
    window.location.replace("/Home/DownloadFile?id=" + id);
}