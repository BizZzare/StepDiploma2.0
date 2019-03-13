$(function () {
    $("#Username").text(getCookie("UserCookie"));

    LoginOnSuccess();
});

function getCookie(name) {
    var matches = document.cookie.match(new RegExp(
        "(?:^|; )" + name.replace(/([\.$?*|{}\(\)\[\]\\\/\+^])/g, '\\$1') + "=([^;]*)"
    ));
    return matches ? decodeURIComponent(matches[1]) : undefined;
}
//при успешном входе загружаем сообщения
function LoginOnSuccess(result) {

    Scroll();
    ShowLastRefresh();

    //каждые пять секунд обновляем чат
    setTimeout("Refresh();", 5000);

    //отправка сообщений по нажатию Enter
    $('#txtMessage').keydown(function (e) {
        if (e.keyCode == 13) {
            e.preventDefault();
            $("#btnMessage").click();
        }
    });

    //установка обработчика нажатия кнопки для отправки сообщений
    $("#btnMessage").click(function () {
        var text = $("#txtMessage").val();
        if (text) {
            $("#txtMessage").val("");
            //обращаемся к методу Index и передаем параметр "chatMessage"
            var href = "/Chat/Index?user=" + encodeURIComponent($("#Username").text());
            href = href + "&chatMessage=" + encodeURIComponent(text);
            $("#ActionLink").attr("href", href).click();
        }
    });

    //обработчик кнопки выхода из чата
    $("#btnLogOff").click(function () {

        //обращаемся к методу Index и передаем параметр "logOff"
        var href = "/Chat/Index?user=" + encodeURIComponent($("#Username").text());
        href = href + "&logOff=true";
        $("#ActionLink").attr("href", href).click();

        document.location = "Home/Index";
    });
}

//при ошибке отображаем сообщение об ошибке при логине
//function LoginOnFailure(result) {
//    $("#Username").val("");
//    $("#Error").text(result.responseText);
//    setTimeout("$('#Error').empty();", 2000);
//}

// каждые пять секунд обновляем поле чата
function Refresh() {
    var href = "/Chat/Index?user=" + encodeURIComponent($("#Username").text());

    $("#ActionLink").attr("href", href).click();
    setTimeout("Refresh();", 5000);
}

//Отображаем сообщение об ошибке
function ChatOnFailure(result) {
    $("#Error").text(result.responseText);
    setTimeout("$('#Error').empty();", 2000);
}

// при успешном получении ответа с сервера
function ChatOnSuccess(result) {
    Scroll();
    ShowLastRefresh();
}

//скролл к низу окна
function Scroll() {
    var win = $('#Messages');
    var height = win[0].scrollHeight;
    win.scrollTop(height);
}

//отображение времени последнего обновления чата
function ShowLastRefresh() {
    var dt = new Date();
    var time = dt.getHours() + ":" + dt.getMinutes() + ":" + dt.getSeconds();
    $("#LastRefresh").text("Последнее обновление было в " + time);
}