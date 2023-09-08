/*
Template Name: Minible - Admin & Dashboard Template
Author: Themesbrand
Website: https://themesbrand.com/
Contact: themesbrand@gmail.com
File: Form Advanced Js File
*/

!function ($) {
    "use strict";

    var AdvancedForm = function () { };

    AdvancedForm.prototype.init = function () {

        // Select2
        $(".select2").select2();

        $(".select2-limiting").select2({
            maximumSelectionLength: 2
        });

        $(".select2-search-disable").select2({
            minimumResultsForSearch: Infinity
        });


        //colorpicker start
        $("#colorpicker-default").spectrum();

        $("#colorpicker-showalpha").spectrum({
            showAlpha: true
        });

        $("#colorpicker-showpaletteonly").spectrum({
            showPaletteOnly: true,
            showPalette: true,
            color: '#34c38f',
            palette: [
                ['#556ee6', 'white', '#34c38f',
                    'rgb(255, 128, 0);', '#50a5f1'],
                ['red', 'yellow', 'green', 'blue', 'violet']
            ]
        });

        $("#colorpicker-togglepaletteonly").spectrum({
            showPaletteOnly: true,
            togglePaletteOnly: true,
            togglePaletteMoreText: 'more',
            togglePaletteLessText: 'less',
            color: '#556ee6',
            palette: [
                ["#000", "#444", "#666", "#999", "#ccc", "#eee", "#f3f3f3", "#fff"],
                ["#f00", "#f90", "#ff0", "#0f0", "#0ff", "#00f", "#90f", "#f0f"],
                ["#f4cccc", "#fce5cd", "#fff2cc", "#d9ead3", "#d0e0e3", "#cfe2f3", "#d9d2e9", "#ead1dc"],
                ["#ea9999", "#f9cb9c", "#ffe599", "#b6d7a8", "#a2c4c9", "#9fc5e8", "#b4a7d6", "#d5a6bd"],
                ["#e06666", "#f6b26b", "#ffd966", "#93c47d", "#76a5af", "#6fa8dc", "#8e7cc3", "#c27ba0"],
                ["#c00", "#e69138", "#f1c232", "#6aa84f", "#45818e", "#3d85c6", "#674ea7", "#a64d79"],
                ["#900", "#b45f06", "#bf9000", "#38761d", "#134f5c", "#0b5394", "#351c75", "#741b47"],
                ["#600", "#783f04", "#7f6000", "#274e13", "#0c343d", "#073763", "#20124d", "#4c1130"]
            ]
        });

        $("#colorpicker-showintial").spectrum({
            showInitial: true
        });

        $("#colorpicker-showinput-intial").spectrum({
            showInitial: true,
            showInput: true
        });


        //Bootstrap-TouchSpin
        var defaultOptions = {
        };

        // touchspin
        $('[data-toggle="touchspin"]').each(function (idx, obj) {
            var objOptions = $.extend({}, defaultOptions, $(obj).data());
            $(obj).TouchSpin(objOptions);
        });

        $("input[name='demo3_21']").TouchSpin({
            initval: 40,
            buttondown_class: "btn btn-primary",
            buttonup_class: "btn btn-primary"
        });
        $("input[name='demo3_22']").TouchSpin({
            initval: 40,
            buttondown_class: "btn btn-primary",
            buttonup_class: "btn btn-primary"
        });

        $("input[name='demo_vertical']").TouchSpin({
            verticalbuttons: true
        });

        //Bootstrap-MaxLength
        $('input#defaultconfig').maxlength({
            warningClass: "badge bg-info",
            limitReachedClass: "badge bg-warning"
        });

        $('input#thresholdconfig').maxlength({
            threshold: 20,
            warningClass: "badge bg-info",
            limitReachedClass: "badge bg-warning"
        });

        $('input#moreoptions').maxlength({
            alwaysShow: true,
            warningClass: "badge bg-success",
            limitReachedClass: "badge bg-danger"
        });

        $('input#alloptions').maxlength({
            alwaysShow: true,
            warningClass: "badge bg-success",
            limitReachedClass: "badge bg-danger",
            separator: ' out of ',
            preText: 'You typed ',
            postText: ' chars available.',
            validate: true
        });

        $('textarea#textarea').maxlength({
            alwaysShow: true,
            warningClass: "badge bg-info",
            limitReachedClass: "badge bg-warning"
        });

        $('input#placement').maxlength({
            alwaysShow: true,
            placement: 'top-left',
            warningClass: "badge bg-info",
            limitReachedClass: "badge bg-warning"
        });


    },
        //init
        $.AdvancedForm = new AdvancedForm, $.AdvancedForm.Constructor = AdvancedForm
}(window.jQuery),


    //Datepicker
    function ($) {
        "use strict";
        $.AdvancedForm.init();
    }(window.jQuery);

$(function () {
    'use strict';

    var $date = $('.docs-date');
    var $container = $('.docs-datepicker-container');
    var $trigger = $('.docs-datepicker-trigger');
    var options = {
        show: function (e) {
            console.log(e.type, e.namespace);
        },
        hide: function (e) {
            console.log(e.type, e.namespace);
        },
        pick: function (e) {
            console.log(e.type, e.namespace, e.view);
        }
    };

    $date.on({
        'show.datepicker': function (e) {
            console.log(e.type, e.namespace);
        },
        'hide.datepicker': function (e) {
            console.log(e.type, e.namespace);
        },
        'pick.datepicker': function (e) {
            console.log(e.type, e.namespace, e.view);
        }
    }).datepicker(options);

    $('.docs-options, .docs-toggles').on('change', function (e) {
        var target = e.target;
        var $target = $(target);
        var name = $target.attr('name');
        var value = target.type === 'checkbox' ? target.checked : $target.val();
        var $optionContainer;

        switch (name) {
            case 'container':
                if (value) {
                    value = $container;
                    $container.show();
                } else {
                    $container.hide();
                }

                break;

            case 'trigger':
                if (value) {
                    value = $trigger;
                    $trigger.prop('disabled', false);
                } else {
                    $trigger.prop('disabled', true);
                }

                break;

            case 'inline':
                $optionContainer = $('input[name="container"]');

                if (!$optionContainer.prop('checked')) {
                    $optionContainer.click();
                }

                break;

            case 'language':
                $('input[name="format"]').val($.fn.datepicker.languages[value].format);
                break;
        }

        options[name] = value;
        $date.datepicker('reset').datepicker('destroy').datepicker(options);
    });

    $('.docs-actions').on('click', 'button', function (e) {
        var data = $(this).data();
        var args = data.arguments || [];
        var result;

        e.stopPropagation();

        if (data.method) {
            if (data.source) {
                $date.datepicker(data.method, $(data.source).val());
            } else {
                result = $date.datepicker(data.method, args[0], args[1], args[2]);

                if (result && data.target) {
                    $(data.target).val(result);
                }
            }
        }
    });

});



// flatpickr

flatpickr('#datepicker-basic', {
    defaultDate: new Date()
});

flatpickr('#datepicker-datetime', {
    enableTime: true,
    dateFormat: "m-d-Y H:i",
    defaultDate: new Date()
});

flatpickr('#datepicker-humanfd', {
    altInput: true,
    altFormat: "F j, Y",
    dateFormat: "Y-m-d",
    defaultDate: new Date()
});

flatpickr('#datepicker-minmax', {
    minDate: "today",
    defaultDate: new Date(),
    maxDate: new Date().fp_incr(14) // 14 days from now
});

flatpickr('#datepicker-disable', {
    onReady: function () {
        this.jumpToDate("2025-01")
    },
    disable: ["2025-01-30", "2025-02-21", "2025-03-08", new Date(2025, 4, 9)],
    dateFormat: "Y-m-d",
    defaultDate: new Date()
});

flatpickr('#datepicker-multiple', {
    mode: "multiple",
    dateFormat: "Y-m-d",
    defaultDate: new Date()
});

flatpickr('#datepicker-range', {
    mode: "range",
    defaultDate: new Date()
});

flatpickr('#datepicker-timepicker', {
    enableTime: true,
    noCalendar: true,
    dateFormat: "H:i",
    defaultDate: new Date()
});

flatpickr('#datepicker-inline', {
    inline: true,
    defaultDate: new Date()
});