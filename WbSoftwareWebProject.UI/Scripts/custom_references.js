
$(function () {

    $('#add_reference').on('shown.bs.modal', function (e) {
        var btn = $(e.relatedTarget);
        var projectid = btn.data("project-id");
        $("#add_reference_body").load("/References/ReferencesModalShow/" + projectid);
    });
});


function doComment(btn) {

    var projectid = $("#ProjectsId").val();
    var namesurname = $("#NameAndSurname").val();
    var company = $("#Company").val();
    var degree = $("#Degree").val();
    var subject = $("#Subject").val();
    var comment = $("#Comment").val();
    var email = $("#Email").val();
    var website = $("#Website").val();

    if (namesurname == null || degree == null || subject == null || comment == null || email == null) {
        alert("Lütfen gerekli alanları doldurunuz.")
    }

    var obj = {
        ProjectsId: projectid,
        NameAndSurname: namesurname,
        Company: company,
        Degree: degree,
        Subject: subject,
        Comment: comment,
        Email: email,
        Website: website
    }

    $.ajax({

        method: "POST",
        url: "/References/AddReferences",
        dataType:"json",
        data: obj

    }).done(function (result) {
        if (result.hasError) {
            alert(result.Message)
        } else {
            alert(result.Message)
           // $('#leave_comment').hide()
        }
    }).fail(function () {
        alert("Sunucuya bağlanırken hata oluştu.")
    })

}