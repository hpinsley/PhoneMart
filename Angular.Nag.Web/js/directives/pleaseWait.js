'use strict';

nagApp.directive('pleaseWait', function () {
    return {
        restrict: 'E',
        templateUrl: 'templates/directives/pleaseWait.html',
        replace: false,
        link: function(scope, element, attrs) {
            var msg = attrs.message || "Please wait..."
            scope.pleaseWaitMessage = msg;
            //element.addClass("hide");
        }
    };
});
