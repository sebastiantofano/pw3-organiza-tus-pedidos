
var form_validation = function() {
    var e = function() {
            jQuery(".form-valide").validate({
                ignore: [],
                errorClass: "invalid-feedback animated fadeInDown",
                errorElement: "div",
                errorPlacement: function(e, a) {
                    jQuery(a).parents(".form-group > div").append(e)
                },
                highlight: function(e) {
                    jQuery(e).closest(".form-group").removeClass("is-invalid").addClass("is-invalid")
                },
                success: function(e) {
                    jQuery(e).closest(".form-group").removeClass("is-invalid"), jQuery(e).remove()
                },
                rules: {
                    "val-username": {
                        required: !0,
                        minlength: 3
                    },
                    "val-email": {
                        required: !0,
                        email: !0
                    },
                    "val-password": {
                        required: !0,
                        minlength: 5
                    },
                    "val-confirm-password": {
                        required: !0,
                        equalTo: "#val-password"
                    },
                    "val-select2": {
                        required: !0
                    },
                    "val-select2-multiple": {
                        required: !0,
                        minlength: 2
                    },
                    "val-suggestions": {
                        required: !0,
                        minlength: 5
                    },
                    "val-skill": {
                        required: !0
                    },
                    "val-currency": {
                        required: !0,
                        currency: ["$", !0]
                    },
                    "val-website": {
                        required: !0,
                        url: !0
                    },
                    "val-phoneus": {
                        required: !0,
                        phoneUS: !0
                    },
                    "val-digits": {
                        required: !0,
                        digits: !0
                    },
                    "val-number": {
                        required: !0,
                        number: !0
                    },
                    "val-range": {
                        required: !0,
                        range: [1, 5]
                    },
                    "val-terms": {
                        required: !0
                    }
                },
                messages: {
                    "val-username": {
                        required: "Por favor ingrese un nombre",
                        minlength: "El nombre debe contener al menos 3 caracteres"
                    },
                    "val-email": "Por favor ingrese un e-mail válido",
                    "val-password": {
                        required: "Por favor ingrese una contraseña",
                        minlength: "Su contraseña debe tener al menos 5 caracteres"
                    },
                    "val-confirm-password": {
                        required: "Por favor ingrese una contraseña",
                        minlength: "Su contraseña debe tener al menos 5 caracteres",
                        equalTo: "Su contraseña no coincide"
                    },
                    "val-select2": "Por favor seleccione un valor!",
                    "val-select2-multiple": "Por favor seleccione al menos 2 valores!",
                    "val-suggestions": "What can we do to become better?",
                    "val-skill": "Por favor seleccione una skill!",
                    "val-currency": "Por favor ingrese un precio!",
                    "val-website": "Por favor ingrese su sitio web!",
                    "val-phoneus": "Por favor ingrese a número telefonico!",
                    "val-digits": "Por favor ingrese solo números!",
                    "val-number": "Por favor ingrese un numero!",
                    "val-range": "Por favor ingrese un número entre 1 y 5!",
                    "val-terms": "Debe aceptar los términos!"
                }
            })
        }
    return {
        init: function() {
            e(), a(), jQuery(".js-select2").on("change", function() {
                jQuery(this).valid()
            })
        }
    }
}();
jQuery(function() {
    form_validation.init()
});