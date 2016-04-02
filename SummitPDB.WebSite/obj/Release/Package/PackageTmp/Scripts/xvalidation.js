$(document).ready(function () {
    $(".validator").click(function (event) {
        event.preventdefault;
        var success = validation();
        if (!success) {
            $("#xerror").fadeIn(800);
        }
        return success;
    });
});

function validation() {
    var required = validationRequired();
    var regular = validationRegularExpression();
    if (required && regular) {
        return true;
    } else {
        return false;
    }
}

function validationRequired() {
    var tagMessage = "<div id='{0}' class='msj-error' style='display:block;'><span>{1}</span></div>";
    var error = true;
    $(".validation").each(function () {
        var element = $(this).context;
        var msg = $(this).attr("xmsg");
        if (msg != undefined) {
            switch (element.tagName) {
                case "INPUT":

                    var idhidden = $(this).attr("HDToValidate");
                    var value = "0";
                    if (idhidden === undefined) {
                        value = "1";
                    } else {
                        value = $("#" + idhidden).val();
                    }

                    if ($(this).val().trim() === "" || value == "0") {
                        if (!$(this).hasClass("error")) {
                            $(this).addClass("error");
                            var msg = tagMessage.replace("{1}", $(this).attr("xmsg"));
                            msg = msg.replace("{0}", $(this).attr("id") + "_msg");
                            $(this).parent().append(msg);
                            xmsg_error($(this).attr("id"));

                        }
                        error = false;
                    }
                    break;
                case "SELECT":
                    if (element.type === "select-multiple") {
                        if ($(this).children("option").length === 0) {
                            if (!$(this).hasClass("error")) {
                                $(this).addClass("error");
                                var msg = tagMessage.replace("{1}", $(this).attr("xmsg"));
                                msg = msg.replace("{0}", $(this).attr("id") + "_msg");
                                $(this).parent().append(msg);
                                xmsg_error($(this).attr("id"));

                            }
                            error = false;
                        }
                    } else {
                        var selection = $(this).attr("selection-null");
                        if (selection == undefined) {
                            selection = "";
                        }

                        if ($(this).val() === selection) {
                            if (!$(this).hasClass("error")) {
                                $(this).addClass("error");
                                var msg = tagMessage.replace("{1}", $(this).attr("xmsg"));
                                msg = msg.replace("{0}", $(this).attr("id") + "_msg");
                                $(this).parent().append(msg);
                                xmsg_error($(this).attr("id"));

                            }
                            error = false;
                        }
                    }
                    break;
                case "TEXTAREA":
                    if ($(this).val().trim() === "") {
                        if (!$(this).hasClass("error")) {
                            $(this).addClass("error");
                            var msg = tagMessage.replace("{1}", $(this).attr("xmsg"));
                            msg = msg.replace("{0}", $(this).attr("id") + "_msg");
                            $(this).parent().append(msg);
                            xmsg_error($(this).attr("id"));
                            error = false;
                        }
                    }
                    break;
                case "UL":
                    if (element.childElementCount <= 1) {
                        if (!$(this).parent().hasClass("error")) {
                            $(this).parent().addClass("error");
                            var msg = tagMessage.replace("{1}", $(this).attr("xmsg"));
                            msg = msg.replace("{0}", $(this).attr("id") + "_msg");
                            $(this).parent().parent().append(msg);
                            xmsg_error($(this).attr("id"));
                            error = false;
                        } else {
                            error = false;
                        }
                    }
                    break;
            }
        }

    });
    return error;
}
function validationRegularExpression() {
    var tagMessage = "<div id='{0}' class='msj-error' style='display:block;'><span>{1}</span></div>";
    var error = true;
    $(".validation").each(function () {
        var element = $(this).context;
        switch (element.tagName) {
            case "INPUT":

                if ($(this).val() != "") {
                    var expression = new RegExp($(this).attr("regular"));
                    var xmsg_regular = $(this).attr("xmsg_regular");
                    var evaluar = $(this).val();
                    if (xmsg_regular != "" && xmsg_regular != undefined) {
                        if (!expression.test(evaluar)) {

                            if (!$(this).hasClass("error")) {
                                var msg = tagMessage.replace("{1}", xmsg_regular);
                                msg = msg.replace("{0}", $(this).attr("id") + "_msg");
                                $(this).parent().append(msg);
                                $(this).addClass("error"); 
                                //xmsg_error($(this).attr("id"));
                            }
                           
                            error = false;
                        }
                    }
                }
                break;
        }
    });
    return error;
}
function xmsg_error(idControl) {
    $("#" + idControl).focus(function () {
        var id = $(this).attr("id");
        if ($("#" + id).val().trim() === "") {
            $("#" + id + "_msg").slideDown("slow");
        }

    });
    $("#" + idControl).blur(function () {
        var id = $(this).attr("id");
        var idhidden = $(this).attr("HDToValidate");
        var value = 0;
        if (idhidden === undefined) {
            value = 1;
        } else {
            value = $("#" + idhidden).val();
        }
        if ($("#" + id).val().trim() != "" && value > 0) {
            $("#" + id + "_msg").slideUp("slow");
            $("#" + id).removeClass("error");
        } else {
            $("#" + id).addClass("error");
            $("#" + id + "_msg").slideDown("slow");
        }
    });
}

function xmsg_warning(id) {
    $(".validation").each(function () {
        if ($(this).attr("xmsg_warning") != undefined) {
            if($(this).val().trim() === ""){
             $("#" + id).append("<li>" + $(this).attr("xmsg_warning") + "</li>");
            }
        }
    });
}

function maximaLongitud(texto, maxlong) {
    var tecla, in_value, out_value;

    if (texto.value.length > maxlong) {
        in_value = texto.value;
        out_value = in_value.substring(0, maxlong);
        texto.value = out_value;
        return false;
    }
    return true;
}