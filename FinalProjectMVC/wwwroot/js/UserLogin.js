$(function () {

    var userLoginButton = $("#UserLogin button[name='login']").click(onUserLoginClick);

    function onUserLoginClick() {
        alert("ihi");
        var url = "/UserAuth/Login";

        var antiForgeryToken = $("#UserLogin input[name='__RequestVerificationToken']").val();

        var email = $("#UserLogin input[name = 'Email']").val();
        var password = $("#UserLogin input[name = 'Password']").val();
        var fullname = $("#UserLogin input[name = 'FullName']").val();


        var userInput = {
            __RequestVerificationToken: antiForgeryToken,
            Email: email,
            Password: password,
            FullName: fullname
        };

        $.ajax({
            type: "POST",
            url: url,
            data: userInput,
            success: function (data) {

                var parsed = $.parseHTML(data);

                var hasErrors = $(parsed).find("input[name='LoginInValid']").val() == "true";

                //if (hasErrors == true) {
                //    $("#UserLoginModal").html(data);

                //    userLoginButton = $("#UserLoginModal button[name='login']").click(onUserLoginClick);

                //    var form = $("#UserLoginForm");

                //    $(form).removeData("validator");
                //    $(form).removeData("unobtrusiveValidation");
                //    $.validator.unobtrusive.parse(form);

                //}

                location.href = 'Home/Index';


            },
            error: function (xhr, ajaxOptions, thrownError) {

                var errorText = "Status: " + xhr.status + " - " + xhr.statusText;

                PresentClosableBootstrapAlert("#alert_placeholder_login", "danger", "Error!", errorText);

                console.error(thrownError + "\r\n" + xhr.statusText + "\r\n" + xhr.responseText);
            }
        });
    }
});