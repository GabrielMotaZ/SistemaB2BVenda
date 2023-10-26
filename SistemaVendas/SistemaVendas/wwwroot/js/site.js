// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(function () {
    $("#loaderbody").addClass('hide');

    $(document).bind('ajaxStart', function () {
        $("#loaderbody").removeClass('hide');
    }).bind('ajaxStop', function () {
        $("#loaderbody").addClass('hide');
    });
});



showInPopup = (url, title) => {
    $.ajax({
        type: "GET",
        url: url,
        success: function (rest) {
            $("#form-modal .modal-body").html(rest);
            $("#form-modal .modal-title").html(title);
            $("#form-modal").modal('show');
            // to make popup draggable
            $('.modal-dialog').draggable({
                handle: ".modal-header"
            });
        }
    })
}


jQueryAjaxPost = form => {
    try {
        $.ajax({
            type: 'POST',
            url: form.action,
            data: new FormData(form),
            contentType: false,
            processData: false,
            success: function (res) {
                if (res.isValid) {
                    $('#view-all').html(res.html)
                    $('#form-modal .modal-body').html('');
                    $('#form-modal .modal-title').html('');
                    $('#form-modal').modal('hide');
                    
                }
                else
                    $('#form-modal .modal-body').html(res.html);
            },
            error: function (err) {
                console.log(err)
            }
        })
        //$(".modal").remove();
        //to prevent default form submit event
        return true;

    } catch (ex) {
        console.log(ex)
    }
}

jQueryAjaxDelete = form => {
    if (confirm('Are you sure to delete this record ?')) {
        try {
            $.ajax({
                type: 'POST',
                url: form.action,
                data: new FormData(form),
                contentType: false,
                processData: false,
                success: function (res) {
                    $('#view-all').html(res.html);
                },
                error: function (err) {
                    console.log(err)
                }
            })
        } catch (ex) {
            console.log(ex)
        }
    }

    //prevent default form submit event
    return false;
}




function validarFormulario(form) {
    // Obtém todos os elementos de entrada no formulário
    var inputs = $(form).find('input');

    // Percorre todos os campos de entrada
    for (var i = 0; i < inputs.length; i++) {
        var input = inputs[i];

        // Verifica se o campo está vazio ou nulo
        if (!input.value) {
            // Se o campo estiver vazio, exibe uma mensagem de erro
            //alert('Por favor, preencha todos os campos.');
        
            exibirPopupDeErro("Por favor, preencha todos os campos"); 
           
            return false;// Impede o envio do formulário
        }
    }

    // Se todos os campos estiverem preenchidos, o formulário será enviado
    return jQueryAjaxPost(form);
}



function exibirPopupDeErro(mensagem) {

    // Remove o popup anterior se existir

    $(".alert").remove();

    // Cria os elementos do popup
    var popup = $('<div class="alert alert-danger" id="popup" style="z-index: 9999; position: fixed;top: 30%;left: 50%;transform: translate(-50%, -50%);">');
    var popupMessage = $('<span id="popup-message">');
    var closeButton = $('<button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>');

    // Adiciona a mensagem e o botão de fechar ao popup
    popupMessage.text(mensagem);
    popup.append(popupMessage, closeButton);

    // Adiciona o popup à página
    $('body').append(popup);

    // Fecha o popup após 4 segundos
    setTimeout(function () {
        popup.fadeTo(500, 0).slideUp(500, function () {
            popup.remove();
        });
    }, 4000);



}


//document.getElementById("close-popup").addEventListener("click", function () {
//    document.getElementById("popup").style.display = "none";
//});
