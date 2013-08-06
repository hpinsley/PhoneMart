'use strict';

nagApp.filter('phoneNumber', function () {
    var phoneNumberFilter = function(input) {
        var letters = input.split("");
        var digits = _.filter(letters, function (c) {
            return c >= "0" && c <= "9";
        });
        var rawDigits = digits.join("");
        if (rawDigits.length == 10)
            return "("  + rawDigits.slice(0, 3) + ") "
                        + rawDigits.slice(3, 6) + "-"
                        + rawDigits.slice(6, 10)
        else {
            return input;   //only format standard US numbers
        }
    };
    return phoneNumberFilter;
});
