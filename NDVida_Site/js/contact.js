(function ($) {
    "use strict";
    // Contact form valitation with jquery.validate plugin
    if ($.fn.validate) {
        var contactForm = $('#contact-form'),
            formBtn = contactForm.find('.btn');

        contactForm.validate({
            rules: {
                contactname: 'required',
                contactsubject: 'required',
                contactemail: {
                    required: true,
                    email: true
                },
                contactmessage: {
                    required: true,
                    //minlength: 50
                }
            },
            messages: {
                contactname: "Esse campo é obrigatório. Por favor informe o seu nome.",
                contactsubject: "Esse campo é obrigatório. Por favor digite um assunto.",
                contactemail: {
                    required: "Esse campo é obrigatório. Por favor informe seu endereço de e-mail.",
                    email: "Por favor informe um endereço de e-mail válido."
                },
                contactmessage: {
                    required: "Esse campo é obrigatório. Por favor digite sua mensagem.",
                    minlength: "Sua mensagem precisa ter pelo menos 50 caracteres."
                }
            },
            submitHandler: function (form) {
                $(document).ajaxStart(function () {
                    formBtn.button('loading');
                }).ajaxStop(function () {
                    formBtn.button('reset');
                });
                /* Ajax handler */
                $.ajax({
                    type: 'post',
                    dataType: "json", // FORMSPREE // Required to set the Accept header
                    // url: 'php/mail.php',
                    url: $(form).attr("action"),
                    data: $(form).serialize(),
                }).done(function (data) {
                    alert('Sua mensagem foi enviada! Entraremos em contato com você em breve.\nObrigado!');
                    location.reload(); // Recarrega a página
                }).fail(function () {
                    alert('Infelizmente não foi possível enviar sua mensagem. Por favor tente novamente mais tarde ou envie um e-mail para ndvida@ndvida.com.br');
                    formBtn.button('reset');
                });
                return false;
            }
        });
    }
})(jQuery);