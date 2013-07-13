'use strict';

nagApp.directive('phoneTabs', function () {
    return {
        restrict: 'E',
        templateUrl: 'templates/directives/phoneTabs.html',
        replace: true
    };
});
