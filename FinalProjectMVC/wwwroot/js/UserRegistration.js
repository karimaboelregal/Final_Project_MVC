$(function () {

    var userLoginButton = $("#UserRegister button[name='register']").click(onUserRegisterClick);

    function onUserRegisterClick() {
        
        var url = "/UserAuth/RegisterUser";

        var antiForgeryToken = $("#UserRegister input[name='__RequestVerificationToken']").val();

        var email = $("#UserRegister input[name = 'Email']").val();
        var password = $("#UserRegister input[name = 'Password']").val();
        var fullname = $("#UserRegister input[name = 'FullName']").val();


        var userInput = {
            __RequestVerificationToken: antiForgeryToken,
            Email: email,
            Password: password,
            FullName: fullname

        };
        alert(fullname);
        $.ajax({
            type: "POST",
            url: url,
            data: userInput,
            success: function (data) {
    
                var parsed = $.parseHTML(data);


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