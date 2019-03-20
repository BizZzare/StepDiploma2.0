$(function () {
    $(".btnDelete").click(function () {
        if (!confirm("Are you sure you want to delete this pet?"))
            return false;
    })
});