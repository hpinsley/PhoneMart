'use strict';

nagApp.directive('phoneList', function () {
    return {
        restrict: 'E',
        templateUrl: 'templates/directives/phoneList.html',
        replace: true
    };
});
